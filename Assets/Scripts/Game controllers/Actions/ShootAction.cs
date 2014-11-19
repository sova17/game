class ShootAction: Action
{
    public override Action Execute(ShipController shipController)//, params object[] objects)
    {
        System.Random rnd = new System.Random();
        shipController.CurrentShip = shipController.ships[rnd.Next(shipController.ships.Count)].GetComponent<Ship>();
        //state = State.initMoving;
        return new InitMovingAction();
    }
}
