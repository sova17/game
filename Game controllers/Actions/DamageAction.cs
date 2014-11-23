class DamageAction : Action {
	public BaseDamageController _damageController;
    Ship defenser;
    ShipDirection direction;

	public DamageAction(BaseDamageController damageController, Ship defenser, ShipDirection direction)
    {
		this._damageController = damageController;
        this.defenser = defenser;
        this.direction = direction;
	}
    
    public override Action Execute(PlayerController shipController)
    {
		Parameters damage = _damageController.CalculateDamage(shipController.CurrentShip, defenser, direction);
		ShipParts oldHitPoints = defenser.Current.Parameters.HitPoints;
		defenser.Current.Parameters -= damage;
		defenser.Storage.OnDamage(oldHitPoints, defenser.Current.Parameters.HitPoints);
        return this;
	}
}