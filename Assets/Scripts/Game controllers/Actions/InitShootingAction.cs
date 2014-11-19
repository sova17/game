class InitShootingAction: Action
{
    public override void Execute(ShipController shipController, params object[] objects)
    {
        shipController.CleanAvailableArea();
        shipController.AvailableArea = shipController.MapController.CalculateAvailableShootingArea(shipController.CurrentShip); ///ships[CurrentShip]);
        //state = State.expectShooting;
        shipController.currentAction = new WaitShootingAction();
    }
}
