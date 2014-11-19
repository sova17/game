class InitMovingAction: Action
{
    public override Action Execute(ShipController shipController)//, params object[] objects)
    {
        shipController.CleanAvailableArea();
        shipController.AvailableArea = shipController.MapController.CalculateAvailableMovingArea(shipController.CurrentShip); ///ships[CurrentShip]);
        //shipController.State = State.expectMoving;
        return new WaitMovingAction();
    }
}
