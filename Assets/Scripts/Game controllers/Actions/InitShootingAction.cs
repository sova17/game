class InitShootingAction: Action
{
    public override Action Execute(ShipController shipController)//, params object[] objects)
    {
        shipController.CleanAvailableArea();
        shipController.AvailableArea = shipController.MapController.CalculateAvailableShootingArea(shipController.CurrentShip); ///ships[CurrentShip]);
        //state = State.expectShooting;
        return new WaitShootingAction();
    }
}
