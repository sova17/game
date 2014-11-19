using UnityEngine;

[System.Serializable]
abstract class BaseDamageController {
	public abstract Parameters CalculateDamage(Ship damager, Ship defenser, ShipDirection direction);
}

[System.Serializable]
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
