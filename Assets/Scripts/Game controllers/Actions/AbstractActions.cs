using UnityEngine;

abstract class Action
{
	public abstract void Execute(ShipController shipController, params object[] objects);
    public Action()
    {

    }
}

abstract class BaseShipAction : Action
{
	public override void Execute(ShipController shipController, params object[] objects) {
		if (objects.Length != 2)
			throw new System.ArgumentException();
		Execute(shipController, (GameObject)objects[0], objects[1]);
	}
	public abstract void Execute(ShipController shipController, Ship ship, object obj);
}

abstract class BaseCellAction : Action
{
	public override void Execute(ShipController shipController, object[] objects)
    {
		if (objects.Length != 1)
			throw new System.ArgumentException();
		Execute(shipController, (Cell)objects[0]);
	}
	public abstract void Execute(ShipController shipController, Cell cell);
}