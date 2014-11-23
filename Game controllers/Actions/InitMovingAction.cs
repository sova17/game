class InitMovingAction: Action
{
    public override Action Execute(PlayerController playerController)
    {
        WaitAction.CleanAvailableArea();
        playerController.StepFinished = false;
        return new WaitMovingAction(playerController.MapController.CalculateAvailableMovingArea(playerController.CurrentShip));
    }
}
