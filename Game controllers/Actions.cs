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
        playerController.CleanStepLimiter();
        playerController.StepFinished = true;
        return new SolveActivityAction();
    }
}

class SolveActivityAction : Action
{
    public override Action Execute(PlayerController playerController)
    {
        if (playerController.CurrentFightingUnit is Ship)
        {
            switch (playerController.stepLimiter[playerController.CurrentFightingUnit])
            {
                case Status.NoAction:
                    return new InitMovingAction();
                case Status.Moved:
                    return new InitShootingAction();
                case Status.Shooted:
                    return new InitMovingAction();
                default:
                    if (playerController.NextAvailableShip())
                        return new SolveActivityAction();
                    else
                        return new FinishStepAction();
            }
        }
        else //if (playerController.CurrentFightingUnit is Fort)
        {
            switch (playerController.stepLimiter[playerController.CurrentFightingUnit])
            {
                case Status.NoAction:
                    return new InitShootingAction();
                default:
                    if (playerController.NextAvailableShip())
                        return new SolveActivityAction();
                    else
                        return new FinishStepAction();
            }
        }
    }
}

class ShootAction : Action
{
    BaseDamageController _damageController;
    FightingUnit defenser;

    public ShootAction(BaseDamageController damageController, FightingUnit defenser)
    {
        this._damageController = damageController;
        this.defenser = defenser;
    }

    public override Action Execute(PlayerController playerController)
    {
        FightingUnitParameters damage = _damageController.CalculateDamage(playerController.CurrentFightingUnit, defenser);
        float oldHitPoints = defenser.Current.Parameters.HitPoints;
        //defenser.Current.Parameters -= damage;
        defenser.Current.AddHitPoints(damage.HitPoints);
        //defenser.Storage.OnDamage(oldHitPoints, defenser.Current.Parameters.HitPoints);
        switch (playerController.stepLimiter[playerController.CurrentFightingUnit])
        {
            case Status.NoAction:
                if (playerController.CurrentFightingUnit is Ship)
                    playerController.stepLimiter[playerController.CurrentFightingUnit] = Status.Shooted;
                else //if (playerController.CurrentFightingUnit is Fort)
                    playerController.stepLimiter[playerController.CurrentFightingUnit] = Status.HasDoneAllPosible;
                break;
            case Status.Moved:
                playerController.stepLimiter[playerController.CurrentFightingUnit] = Status.HasDoneAllPosible;
                break;
            default:
                throw new System.InvalidOperationException();
        }
        return new SolveActivityAction();
    }
}

class MoveAction : Action
{
    Cell MoveToHex;

    public MoveAction(Cell moveToHex)
    {
        MoveToHex = moveToHex;
    }

    public override Action Execute(PlayerController playerController)
    {
        //if (!cell.IsAvailableRouteCell)
        //	throw new System.ArgumentOutOfRangeException();
        if (!(playerController.CurrentFightingUnit is Ship))
            throw new System.Exception();
        Ship ship = playerController.CurrentFightingUnit as Ship;

        GameObject.FindGameObjectWithTag(Tags.MainCamera).transform.LookAt(ship.transform.position);
        Vector3 moveTo = new Vector3(MoveToHex.transform.position.x, ship.transform.position.y, MoveToHex.transform.position.z);
        ship.transform.LookAt(moveTo);
        if ((ship.transform.position - moveTo).magnitude < 1.0)
        {
            ship.transform.position = moveTo;
            ship.CurrentCell = MoveToHex;
            switch(playerController.stepLimiter[playerController.CurrentFightingUnit])
            {
                case Status.NoAction:
                    playerController.stepLimiter[playerController.CurrentFightingUnit] = Status.Moved;
                    break;
                case Status.Shooted:
                    playerController.stepLimiter[playerController.CurrentFightingUnit] = Status.HasDoneAllPosible;
                    break;
                default:
                    throw new System.InvalidOperationException();
            }
            return new SolveActivityAction();
        }
        else
        {
            ship.transform.position = Vector3.Lerp(ship.transform.position, moveTo, (ship.Current.Parameters as ShipParameters).Speed * Time.deltaTime);
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
        return new WaitMovingAction(playerController.MapController.CalculateAvailableMovingArea(playerController.CurrentFightingUnit as Ship));
    }
}

class InitShootingAction : Action
{
    public override Action Execute(PlayerController playerController)
    {
        WaitAction.CleanAvailableArea();
        return new WaitShootingAction(playerController.MapController.CalculateAvailableShootingArea(playerController.CurrentFightingUnit));
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
        if (Input.GetKeyDown(KeyCode.Space) == true && playerController.stepLimiter[playerController.CurrentFightingUnit] != Status.Shooted)
            return new InitShootingAction();
        if (Input.GetKeyDown(KeyCode.Tab) == true)
        {
            playerController.NextAvailableShip();
            return new SolveActivityAction();
        }
        if (Input.GetKeyDown(KeyCode.Return) == true)
            return new FinishStepAction();
        return this;
    }
}

class WaitShootingAction : WaitAction
{
    public WaitShootingAction(List<Cell> availableArea) : base(availableArea) { }
    public override Action Execute(PlayerController playerController)
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && playerController.stepLimiter[playerController.CurrentFightingUnit] != Status.Moved)
            return new InitMovingAction();
        if (Input.GetKeyDown(KeyCode.Tab) == true)
        {
            playerController.NextAvailableShip();
            return new SolveActivityAction();
        }
        if (Input.GetKeyDown(KeyCode.Return) == true)
            return new FinishStepAction();
        return this;
    }
}