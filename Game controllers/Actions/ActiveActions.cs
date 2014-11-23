using UnityEngine;

class ShootAction: Action
{
    public override Action Execute(PlayerController playerController)
    {
        System.Random rnd = new System.Random();
        playerController.CurrentShip = playerController.ships[rnd.Next(playerController.ships.Count)].GetComponent<Ship>();
        playerController.StepFinished = true;
        return new InitMovingAction();
    }
}

class MoveAction : Action
{
    Cell MoveToHex;

    public MoveAction(Cell moveToHex)
    {
        MoveToHex = moveToHex;
    }

	public override Action Execute(PlayerController shipController)//, Cell cell)
	{
		//if (!cell.IsAvailableRouteCell)
		//	throw new System.ArgumentOutOfRangeException();
		Ship ship = shipController.CurrentShip;

        GameObject.FindGameObjectWithTag(Tags.MainCamera).transform.LookAt(ship.transform.position);
        Vector3 moveTo = new Vector3(MoveToHex.transform.position.x, ship.transform.position.y, MoveToHex.transform.position.z);
        ship.transform.LookAt(moveTo);
        if ((ship.transform.position - moveTo).magnitude < 1.0)
        {
            ship.transform.position = moveTo;
            ship.CurrentCell = MoveToHex;
            return new InitShootingAction();
        }
        else
        {
            ship.transform.position = Vector3.Lerp(ship.transform.position, moveTo, ship.Current.Parameters.Speed * Time.deltaTime);
            return this;
        }
		/*shipController.SubShip(ship);
		ship.Current.Parameters -= cell.Bonus;
		shipController.AddShip(ship, cell);*/
	}
}