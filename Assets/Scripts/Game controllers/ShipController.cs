using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
class ShipController: MonoBehaviour {
    public List<Ship> ships;
    public List<Ship> nextStepShips;
	bool IsRoundPlay;
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

	public ShipController(Ship currentShip, MapController mapController)
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
            if (!ships.Contains(ship))
			    ships.Add(ship);
            ship.CurrentCell.IsFree = false;
            ship.TryingToSelect += OnShipSelecting;
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
            CurrentShip = ship;
    }

    private void OnCellSelecting(Cell cell)
    {
        if (WaitAction.isAvalableAreaContainsCell(cell))
            if (currentAction is WaitMovingAction)
            {
                currentAction = new MoveAction(cell);
            }
            else if (currentAction is WaitShootingAction)
            {
                currentAction = new ShootAction();
            }
    }

	public void AddShip(Ship ship, Cell cell) {
		if (!IsRoundPlay)
			ships.Add(ship);
		else
			nextStepShips.Add(ship);
	    CurrentShip.CurrentCell.IsFree = false;
	}

	public void SubShip(Ship ship) {
		CurrentShip.CurrentCell.IsFree = true;
		ships.Remove(ship);
	}

    public Action currentAction;
	public void  Update()
	{
        currentAction = currentAction.Execute(this);
	}
}