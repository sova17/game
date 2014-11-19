[System.Serializable]
class DamageAction : BaseShipAction {
	public BaseDamageController _damageController;

	public DamageAction(BaseDamageController damageController) {
		this._damageController = damageController;
	}
	public override void Execute(ShipController shipController, Ship ship, object obj) {
		Execute(shipController, ship, (ShipDirection)obj);
	}
	public void Execute(ShipController shipController, Ship ship, ShipDirection direction) {
		Parameters damage = _damageController.CalculateDamage(shipController.CurrentShip, ship, direction);
		ShipParts oldHitPoints = ship.Current.Parameters.HitPoints;
		ship.Current.Parameters -= damage;
		ship.Storage.OnDamage(oldHitPoints, ship.Current.Parameters.HitPoints);
	}
}