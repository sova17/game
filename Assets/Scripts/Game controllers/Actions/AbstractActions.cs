using UnityEngine;

abstract class Action
{
    public abstract Action Execute(ShipController shipController);//, params object[] objects);
}
/*
abstract class BaseShipAction : Action
{
	public override Action Execute(ShipController shipController, params object[] objects) {
		if (objects.Length != 2)
			throw new System.ArgumentException();
		return Execute(shipController, (GameObject)objects[0], objects[1]);
	}
	public abstract Action Execute(ShipController shipController, Ship ship, object obj);
}

abstract class BaseCellAction : Action
{
	public override Action Execute(ShipController shipController, object[] objects)
    {
		if (objects.Length != 1)
			throw new System.ArgumentException();
		return Execute(shipController, (Cell)objects[0]);
	}
	public abstract Action Execute(ShipController shipController, Cell cell);
}*/