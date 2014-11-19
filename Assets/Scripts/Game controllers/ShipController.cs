using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
class ShipController: MonoBehaviour {
	//SortedList<Ship, Cell> ships;
    public List<Ship> ships;
	SortedList<Ship, Cell> nextStepShips;
	bool IsRoundPlay;
    //public	Action _wait;
	//public Action _defense;
	//public Action _rotate;
	//public Action _damage = new DamageAction(new DamageController());
	//public Action _go;
    public  Ship _currentShip;

	public MapController MapController;

	/*public Action Wait
	{
		get { return _wait; }
		protected set { _wait = value; }
	}*/
	/*public Action Defense
	{
		get { return _defense; }
		protected set { _defense = value; }
	}*/
	/*public Action Rotate
	{
		get { return _rotate; }
		protected set { _rotate = value; }
	}
	*/
	/*public Action Damage
	{
		get { return _damage; }
		protected set { _damage = value; }
	}*/
    //public InitMovingAction InitMoving { get; set; }
    //public WaitMovingAction WaitMoving { get; set; }
    //public MoveAction Move { get; set; }
    //public InitShootingAction InitShooting { get; set; }
    //public WaitShootingAction WaitShooting { get; set; }
    //public ShootAction Shoot { get; set; } 
    public Ship CurrentShip
    {
        get { return _currentShip; }
        set 
        {
            _currentShip = value;
            //state = State.initMoving;
            currentAction = new InitMovingAction();
        }
    }

	public ShipController(Ship currentShip, MapController mapController,
	                      Action wait, Action defense, Action damage, Action go)
	{
		CurrentShip = currentShip;
		MapController = mapController;
		//Wait = wait;
		//Defense = defense;
		//Damage = damage;
		//Go = go;
        Awake();
	}

	public void Awake()
	{
		//ships = new SortedList<Ship, Cell>();
		//nextStepShips = new SortedList<Ship, Cell>();
        //AvailableArea = new List<Cell>();
        //InitMoving = new InitMovingAction();
        //WaitMoving = new WaitMovingAction();
        //Move = new MoveAction();
        //InitShooting = new InitShootingAction();
        //WaitShooting = new WaitShootingAction();
        //Shoot = new ShootAction();
		IEnumerable<GameObject> shipGOs  = GameObject.FindGameObjectsWithTag(Tags.Ship);
		foreach(var shipGO in shipGOs)
		{
			Ship ship = shipGO.GetComponent<Ship>();
			//ships.Add(ship, ship.CurrentCell);
            ship.CurrentCell.IsFree = false;
            ship.TryingToSelect += OnShipSelecting;
		}
		foreach(Cell cell in MapController.Map)
		{
			cell.TryingToSelect += OnCellSelecting;
		}
		//state = State.initMoving;
        currentAction = new InitMovingAction();
	}

    private void OnShipSelecting(Ship ship)
    {
        if (state != State.isMoving && state != State.isShooting)
            CurrentShip = ship;
    }

    private void OnCellSelecting(Cell cell)
    {
        if (AvailableArea.Contains(cell))
            if (currentAction is WaitMovingAction)
            {
                currentAction = new MoveAction(cell);
            }
            else if (currentAction is WaitShootingAction)
            {
                currentAction = new ShootAction();
            }
            /*switch(state)
            {
                case State.expectMoving:
                        MoveToHex = cell;
                        state = State.isMoving;
                    break;
                case State.expectShooting:
                    state = State.isShooting;
                    break;
                default:
                    break;
            }*/
    }

	/*public void AddShip(Ship ship, Cell cell) {
		if (!IsRoundPlay)
			ships.Add(ship, cell);
		else
			nextStepShips.Add(ship, cell);
		MapController.Map[cell.X, cell.Z].IsFree = false;
	}

	public void SubShip(Ship ship) {
		int index = 0;
		for (int i = 0; i < ships.Count; i++)
			if (ships.Keys[i].Equals(ship)) {
				index = i;
				break;
			}
		MapController.Map[ships.Values[index].X, ships.Values[index].Z].IsFree = true;
		ships.RemoveAt(index);
	}
    */
	State state;
    public State State
    {
        get { return state; }
        set { state = value; }
    }

	//public Cell MoveToHex;
    public List<Cell> AvailableArea;

    public void CleanAvailableArea()
    {
        foreach (Cell cell in AvailableArea)
        {
            cell.renderer.material = MapController.SeaSurface;
        }
    }

    public Action currentAction;
	public void  Update()
	{
        currentAction = currentAction.Execute(this);
		/*switch(state)
		{
			case State.initMoving:
                CleanAvailableArea();
				AvailableArea = MapController.CalculateAvailableMovingArea(CurrentShip); ///ships[CurrentShip]);
				state = State.expectMoving;
				break;

			case State.isMoving:
                GameObject.FindGameObjectWithTag(Tags.MainCamera).transform.LookAt(CurrentShip.transform.position);
                Vector3 moveTo = new Vector3(MoveToHex.transform.position.x, CurrentShip.transform.position.y, MoveToHex.transform.position.z);
                CurrentShip.transform.LookAt(moveTo);// Quaternion.Lerp(CurrentShip.transform.rotation, Quaternion.LookRotation(MoveToHex.transform.position), 0.25f);
                if ((CurrentShip.transform.position - moveTo).magnitude < 1.0)
				{
                    CurrentShip.transform.position = moveTo;
                    CurrentShip.CurrentCell = MoveToHex;
					state = State.initShooting;
				}
				else
				{
					CurrentShip.transform.position = Vector3.Lerp(CurrentShip.transform.position, moveTo, CurrentShip.Current.Parameters.Speed * Time.deltaTime);
				}
                break;

			case State.initShooting:
                CleanAvailableArea();
			    AvailableArea =	MapController.CalculateAvailableShootingArea(CurrentShip); ///ships[CurrentShip]);
				state = State.expectShooting;
				break;

			case State.isShooting:
                System.Random rnd = new System.Random();
                CurrentShip = ships[rnd.Next(ships.Count)].GetComponent<Ship>();
                state = State.initMoving;
				break;
		}
         * */
	}
}

public enum State {initMoving, expectMoving, isMoving, initShooting, expectShooting, isShooting }

