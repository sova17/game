class InitShootingAction: Action
{
    public override Action Execute(ShipController shipController)
    {
        WaitAction.CleanAvailableArea();
        return new WaitShootingAction(shipController.MapController.CalculateAvailableShootingArea(shipController.CurrentShip));
    }
}
