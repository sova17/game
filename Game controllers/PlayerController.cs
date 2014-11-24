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
			currentAction = new InitMovingAction();
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

	public PlayerController(Ship currentShip, MapController mapController)
	{
		CurrentShip = currentShip;
		MapController = mapController;
		Awake();
	}

	public void Awake()
	{
		IEnumerable<GameObject> shipGOs  = GameObject.FindGameObjectsWithTag(Tags.Ship);
		foreach(var shipGO in shipGOs)
		{
			Ship ship = shipGO.GetComponent<Ship>();
			ship.CurrentCell.IsFree = false;
			if (ships.Contains(ship))
				ship.TryingToSelect += OnShipSelecting;
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
			stepFinished(this);
		}
		else if (currentAction is ShootAction)
		{
			currentAction = new ShootAction(new DamageController(), ship);
		}
	}

	private void OnAttack(Ship ship)
	{
		Debug.Log("DIE " + ship + "!!!");
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
		//if (!IsRoundPlay)
			ships.Add(ship);
		//else
			//nextStepShips.Add(ship);
		CurrentShip.CurrentCell.IsFree = false;
	}

	public void SubShip(Ship ship) {
		CurrentShip.CurrentCell.IsFree = true;
		ships.Remove(ship);
	}

	public Action currentAction;
	public void  Tick()
	{
		//Debug.Log(this + "   " + currentAction.GetType() + "   " + StepFinished) ;
		//if (!StepFinished)
			currentAction = currentAction.Execute(this);
		/*else
		{
			StepFinished = false;
			if (stepFinished != null)
				stepFinished(this);
		}*/
	}
}