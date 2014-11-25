using UnityEngine;

abstract class BaseDamageController {
	public abstract Parameters CalculateDamage(Ship damager, Ship defenser);
}

class DamageController : BaseDamageController {
	public override Parameters CalculateDamage(Ship damager, Ship defenser) {
        return new Parameters() { HitPoints = 5.0f };
	}
}