class InitMovingAction: Action
{
    public override Action Execute(ShipController shipController)
    {
        WaitAction.CleanAvailableArea();
        return new WaitMovingAction(shipController.MapController.CalculateAvailableMovingArea(shipController.CurrentShip));
    }
}
