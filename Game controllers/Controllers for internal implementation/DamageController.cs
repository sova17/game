using UnityEngine;

abstract class BaseDamageController {
	public abstract FightingUnitParameters CalculateDamage(FightingUnit damager, FightingUnit defenser);
}

class DamageController : BaseDamageController {
	public override FightingUnitParameters CalculateDamage(FightingUnit damager, FightingUnit defenser) {
        if (defenser is Ship)
            return new ShipParameters() { HitPoints = -5.0f };
        else //if (defenser is Fort)
            return new FortParameters() { HitPoints = -5.0f };

	}
}