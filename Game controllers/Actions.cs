using UnityEngine;
using System.Collections.Generic;

abstract class Action
{
    public abstract Action Execute(PlayerController playerController);
}

class FinishStepAction: Action
{
    public override Action Execute(PlayerController playerController)
    {
        Debug.Log(playerController + "on FinishStepAction");
        playerController.StepFinished = true;
        return new InitMovingAction();
    }
}

class ShootAction : Action
{
    BaseDamageController _damageController;
    Ship defenser;

    public ShootAction(BaseDamageController damageController, Ship defenser)
    {
        this._damageController = damageController;
        this.defenser = defenser;
    }

    public override Action Execute(PlayerController playerController)
    {
        Debug.Log(playerController + "on ShootAction");
        Parameters damage = _damageController.CalculateDamage(playerController.CurrentShip, defenser);
        float oldHitPoints = defenser.Current.Parameters.HitPoints;
        defenser.Current.Parameters -= damage;
        //defenser.Storage.OnDamage(oldHitPoints, defenser.Current.Parameters.HitPoints);
        return new FinishStepAction();
    }
}

class MoveAction : Action
{
    Cell MoveToHex;

    public MoveAction(Cell moveToHex)
    {
        MoveToHex = moveToHex;
    }

    public override Action Execute(PlayerController playerController)//, Cell cell)
    {
        Debug.Log(playerController + "on MoveAction");

        //if (!cell.IsAvailableRouteCell)
        //	throw new System.ArgumentOutOfRangeException();
        Ship ship = playerController.CurrentShip;

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
        Debug.Log(playerController + "on InitMovingAction");
        WaitAction.CleanAvailableArea();
        playerController.StepFinished = false;
        return new WaitMovingAction(playerController.MapController.CalculateAvailableMovingArea(playerController.CurrentShip));
    }
}

class InitShootingAction : Action
{
    public override Action Execute(PlayerController playerController)
    {
        Debug.Log(playerController + "on InitShootingAction");
        WaitAction.CleanAvailableArea();
        return new WaitShootingAction(playerController.MapController.CalculateAvailableShootingArea(playerController.CurrentShip));
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
    public override Action Execute(PlayerController playerController)
    {
        Debug.Log(playerController + "on WaitMovingAction");
        if (Input.GetKeyDown(KeyCode.Space) == true)
            return new InitShootingAction();
        if (Input.GetKeyDown(KeyCode.Tab) == true)
        {
            playerController.NextShip();
            return new InitMovingAction();
        }
        return this;
    }
}

class WaitShootingAction : WaitAction
{
    public WaitShootingAction(List<Cell> availableArea) : base(availableArea) { }
    public override Action Execute(PlayerController playerController)
    {
        Debug.Log(playerController + "on WaitShootingAction");
        if (Input.GetKeyDown(KeyCode.Space) == true)
            return new InitMovingAction();
        if (Input.GetKeyDown(KeyCode.Tab) == true)
        {
            playerController.NextShip();
            return new InitMovingAction();
        }
        return this;
    }
}