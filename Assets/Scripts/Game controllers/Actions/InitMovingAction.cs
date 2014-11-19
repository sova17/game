class InitMovingAction: Action
{
    public override void Execute(ShipController shipController, params object[] objects)
    {
        shipController.CleanAvailableArea();
        shipController.AvailableArea = shipController.MapController.CalculateAvailableMovingArea(shipController.CurrentShip); ///ships[CurrentShip]);
        //shipController.State = State.expectMoving;
        shipController.currentAction = new WaitMovingAction();
    }
}
