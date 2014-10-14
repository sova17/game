using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseCell {
		public Int32 X { get; set; }
		public Int32 Y { get; set; }
		public Int32 Depth { get; set; }
		public TBattleParameters BonusSpecificators { get; set; }
		// Here will be yet some parameters, for example about weather in the cell, etc
	}
	abstract class TBaseMap {
		// supposedly Cell[][] will be here
	}
}