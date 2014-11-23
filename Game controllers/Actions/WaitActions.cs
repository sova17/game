using System.Collections.Generic;

abstract class WaitAction: Action
{
    protected static List<Cell> AvailableArea;

    public WaitAction(List<Cell> availableArea)
    {
        AvailableArea = availableArea;
    }

    public static void CleanAvailableArea()
    {
        if (AvailableArea !=null)
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

class WaitMovingAction: WaitAction
{
    public WaitMovingAction(List<Cell> availableArea): base(availableArea) { }
    public override Action Execute(PlayerController shipController)//, params object[] objects)
    {
        return this;
    }
}

class WaitShootingAction : WaitAction
{
    public WaitShootingAction(List<Cell> availableArea): base(availableArea) { }
    public override Action Execute(PlayerController shipController)//, params object[] objects)
    {
        return this;
    }
}