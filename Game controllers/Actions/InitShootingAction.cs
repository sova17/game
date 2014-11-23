class InitShootingAction: Action
{
    public override Action Execute(PlayerController shipController)
    {
        WaitAction.CleanAvailableArea();
        return new WaitShootingAction(shipController.MapController.CalculateAvailableShootingArea(shipController.CurrentShip));
    }
}
