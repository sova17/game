using UnityEngine;

abstract class BaseDamageController {
	public abstract Parameters CalculateDamage(Ship damager, Ship defenser, ShipDirection direction);
}

class DamageController : BaseDamageController {
	public override Parameters CalculateDamage(Ship damager, Ship defenser, ShipDirection direction) {
		// TODO
		throw new System.NotImplementedException();
	}
}
enum ShipDirection {
	Left,
	Right,
	Tail,
	Head,
	Air
}
