using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
class PlayerController: MonoBehaviour {
	public List<FightingUnit> FightingUnits;
	[SerializeField]
	private FightingUnit currentFightingUnit;

	public MapController MapController;

	public FightingUnit CurrentFightingUnit
	{
		get { return currentFightingUnit; }
		set 
		{
			currentFightingUnit = value;
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

    public Dictionary<FightingUnit, Status> stepLimiter;

    public void CleanStepLimiter()
    { 
        foreach(var fightingUnit in FightingUnits)
        {
            stepLimiter[fightingUnit] = Status.NoAction;
        }
    }

	public PlayerController(FightingUnit currentFightingUnit, MapController mapController)
	{
		CurrentFightingUnit = currentFightingUnit;
		MapController = mapController;
		Awake();
	}

	public void Awake()
	{
		GameObject[] shipGOs  = GameObject.FindGameObjectsWithTag(Tags.Ship);
        GameObject[] fortGOs = GameObject.FindGameObjectsWithTag(Tags.Fort);
        stepLimiter = new Dictionary<FightingUnit, Status>();
        foreach (FightingUnit fightingUnit in FightingUnits)
        {
            fightingUnit.CurrentCell.IsFree = false;
            fightingUnit.TryingToSelect += OnFightingUnitSelecting;
            fightingUnit.Destroying += OnFightingUnitDestroying;
            stepLimiter.Add(fightingUnit, Status.NoAction);
        }
        foreach (var shipGO in shipGOs)
        {
            Ship ship = shipGO.GetComponent<Ship>();
            if (!FightingUnits.Contains(ship))
                ship.TryingToSelect += OnAttack;
        }
        foreach (var fortGO in fortGOs)
        {
            Fort fort = fortGO.GetComponent<Fort>();
            if(!FightingUnits.Contains(fort))
                fort.TryingToSelect += OnAttack;
        }
		foreach(Cell cell in MapController.Map)
		{
			cell.TryingToSelect += OnCellSelecting;
		}
		currentAction = new SolveActivityAction();
	}

    private void OnFightingUnitDestroying(FightingUnit fightingUnit)
    {
        FightingUnits.Remove(fightingUnit);
    }

	private void OnFightingUnitSelecting(FightingUnit unit)
	{
		if (!(currentAction is MoveAction || currentAction is ShootAction))
			CurrentFightingUnit = unit;
	}

	private void OnAttack(FightingUnit unit)
	{
        if (currentAction is WaitShootingAction && WaitAction.isAvalableAreaContainsCell(unit.CurrentCell))
        {
            currentAction = new ShootAction(new DamageController(), unit);
        }
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
        FightingUnits.Add(ship);
		ship.CurrentCell.IsFree = false;
	}

	public void SubShip(Ship ship) {
		ship.CurrentCell.IsFree = true;
		FightingUnits.Remove(ship);
	}

    public bool NextAvailableShip()
    {
        int index = FightingUnits.IndexOf(CurrentFightingUnit);
        for (int i = (index + 1) % FightingUnits.Count; i != index  ; i = (i + 1) % FightingUnits.Count)
            if (stepLimiter[FightingUnits[i]] != Status.HasDoneAllPosible)
            {
                CurrentFightingUnit = FightingUnits[i];
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

public enum Status { NoAction, Moved, Shooted, HasDoneAllPosible }