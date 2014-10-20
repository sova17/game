﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseDamageController {
		public abstract Int32 CalculateDamage(TShip damager, TShip defenser, TDirection direction);
		/////////// TODO //////////////
	}
	enum TDirection {
		Left,
		Right,
		Tail,
		Head,
		Air
	}
}
