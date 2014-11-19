/*[System.Serializable]
class DamageAction : BaseShipAction {
	public BaseDamageController _damageController;

	public DamageAction(BaseDamageController damageController) {
		this._damageController = damageController;
	}
	public override Action Execute(ShipController shipController, Ship ship, object obj) {
		return Execute(shipController, ship, (ShipDirection)obj);
	}
	public Action Execute(ShipController shipController, Ship ship, ShipDirection direction) {
		Parameters damage = _damageController.CalculateDamage(shipController.CurrentShip, ship, direction);
		ShipParts oldHitPoints = ship.Current.Parameters.HitPoints;
		ship.Current.Parameters -= damage;
		ship.Storage.OnDamage(oldHitPoints, ship.Current.Parameters.HitPoints);
        return this;
	}
}*/