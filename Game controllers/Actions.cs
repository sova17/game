using UnityEngine;
using System.Collections.Generic;

abstract class Action
{
    public abstract Action Execute(PlayerController shipController);//, params object[] objects);
}

class ShootAction : Action
{
    BaseDamageController _damageController;
    Ship defenser;
    ShipDirection direction;

    public ShootAction(BaseDamageController damageController = null, Ship defenser = null)
    {
        this._damageController = damageController;
        this.defenser = defenser;
    }

    public override Action Execute(PlayerController playerController)
    {
        /*Parameters damage = _damageController.CalculateDamage(playerController.CurrentShip, defenser, direction);
        int oldHitPoints = defenser.Current.Parameters.HealthPoints;
        defenser.Current.Parameters -= damage;
        defenser.Storage.OnDamage(oldHitPoints, defenser.Current.Parameters.HealthPoints);*/
        
        System.Random rnd = new System.Random();
        playerController.CurrentShip = playerController.ships[rnd.Next(playerController.ships.Count)].GetComponent<Ship>();
        playerController.StepFinished = true;
        return new InitMovingAction();
    }
}

class MoveAction : Action
{
    Cell MoveToHex;

    public MoveAction(Cell moveToHex)
    {
        MoveToHex = moveToHex;
    }

    public override Action Execute(PlayerController shipController)//, Cell cell)
    {
        //if (!cell.IsAvailableRouteCell)
        //	throw new System.ArgumentOutOfRangeException();
        Ship ship = shipController.CurrentShip;

        GameObject.FindGameObjectWithTag(Tags.MainCamera).transform.LookAt(ship.transform.position);
        Vector3 moveTo = new Vector3(MoveToHex.transform.position.x, ship.transform.position.y, MoveToHex.transform.position.z);
        ship.transform.LookAt(moveTo);
        if ((ship.transform.position - moveTo).magnitude < 1.0)
        {
            ship.transform.position = moveTo;
            ship.CurrentCell = MoveToHex;
            return new InitShootingAction();
        }
        else
        {
            ship.transform.position = Vector3.Lerp(ship.transform.position, moveTo, ship.Current.Parameters.Speed * Time.deltaTime);
            return this;
        }
        /*shipController.SubShip(ship);
        ship.Current.Parameters -= cell.Bonus;
        shipController.AddShip(ship, cell);*/
    }
}

class InitMovingAction : Action
{
    public override Action Execute(PlayerController playerController)
    {
        WaitAction.CleanAvailableArea();
        playerController.StepFinished = false;
        return new WaitMovingAction(playerController.MapController.CalculateAvailableMovingArea(playerController.CurrentShip));
    }
}

class InitShootingAction : Action
{
    public override Action Execute(PlayerController shipController)
    {
        WaitAction.CleanAvailableArea();
        return new WaitShootingAction(shipController.MapController.CalculateAvailableShootingArea(shipController.CurrentShip));
    }
}

abstract class WaitAction : Action
{
    protected static List<Cell> AvailableArea;

    public WaitAction(List<Cell> availableArea)
    {
        AvailableArea = availableArea;
    }

    public static void CleanAvailableArea()
    {
        if (AvailableArea != null)
            foreach (Cell cell in AvailableArea)
            {
                cell.renderer.material = MapController.Instance().SeaSurface;
            }
    }

    public static bool isAvalableAreaContainsCell(Cell cell)
    {
        if (AvailableArea != null)
            return AvailableArea.Contains(cell);
        return false;
    }
}

class WaitMovingAction : WaitAction
{
    public WaitMovingAction(List<Cell> availableArea) : base(availableArea) { }
    public override Action Execute(PlayerController shipController)//, params object[] objects)
    {
        return this;
    }
}

class WaitShootingAction : WaitAction
{
    public WaitShootingAction(List<Cell> availableArea) : base(availableArea) { }
    public override Action Execute(PlayerController shipController)//, params object[] objects)
    {
        return this;
    }
}