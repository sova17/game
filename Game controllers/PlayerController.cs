using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
class PlayerController: MonoBehaviour {
	public List<Ship> ships;
	[SerializeField]
	private Ship currentShip;

	public MapController MapController;

	public Ship CurrentShip
	{
		get { return currentShip; }
		set 
		{
			currentShip = value;
			//currentAction = new InitMovingAction();
		}
	}

	public bool StepFinished
	{
		set 
		{
			if (value == true)
				stepFinished(this);
		}
	}

	public event System.Action<PlayerController> stepFinished;

    public Dictionary<Ship, ShipStatus> stepLimiter;

    public void CleanStepLimiter()
    { 
        foreach(var ship in ships)
        {
            stepLimiter[ship] = ShipStatus.NoAction;
        }
    }

	public PlayerController(Ship currentShip, MapController mapController)
	{
		CurrentShip = currentShip;
		MapController = mapController;
		Awake();
	}

	public void Awake()
	{
		IEnumerable<GameObject> shipGOs  = GameObject.FindGameObjectsWithTag(Tags.Ship);
        stepLimiter = new Dictionary<Ship, ShipStatus>();
		foreach(var shipGO in shipGOs)
		{
			Ship ship = shipGO.GetComponent<Ship>();
			ship.CurrentCell.IsFree = false;
            if (ships.Contains(ship))
            {
                ship.TryingToSelect += OnShipSelecting;
                stepLimiter.Add(ship, ShipStatus.NoAction);
            }
            else
                ship.TryingToSelect += OnAttack;
		}
		foreach(Cell cell in MapController.Map)
		{
			cell.TryingToSelect += OnCellSelecting;
		}
		currentAction = new InitMovingAction();
	}

	private void OnShipSelecting(Ship ship)
	{
		if (!(currentAction is MoveAction || currentAction is ShootAction))
		{
			CurrentShip = ship;
			//stepFinished(this);
		}
	}

	private void OnAttack(Ship ship)
	{
        if (currentAction is WaitShootingAction && WaitAction.isAvalableAreaContainsCell(ship.CurrentCell))
            currentAction = new ShootAction(new DamageController(), ship);
	}

	private void OnCellSelecting(Cell cell)
	{
		if (WaitAction.isAvalableAreaContainsCell(cell))
			if (currentAction is WaitMovingAction)
			{
				currentAction = new MoveAction(cell);
			}
	}

	public void AddShip(Ship ship, Cell cell) {
        ships.Add(ship);
		ship.CurrentCell.IsFree = false;
	}

	public void SubShip(Ship ship) {
		ship.CurrentCell.IsFree = true;
		ships.Remove(ship);
	}

    public bool NextAvailableShip()
    {
        int index = ships.IndexOf(CurrentShip);
        for (int i = (index + 1) % ships.Count; i != index  ; i = (i + 1) % ships.Count)
            if (stepLimiter[ships[i]] != ShipStatus.MovedAndShooted)
            {
                CurrentShip = ships[i];
                return true;
            }
        return false;
    }

	private Action currentAction;
	public void  Tick()
	{
        currentAction = currentAction.Execute(this);
	}
}

public enum ShipStatus { NoAction, Moved, Shooted, MovedAndShooted }