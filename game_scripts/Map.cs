using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseCell {
		public int X { get; set; }
		public int Y { get; set; }
		public int Depth { get; set; }
		//public TSpecificators BonusSpecificators { get; set; }
	}
	abstract class TBaseMap {
	}
}