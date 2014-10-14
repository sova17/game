using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseShip {
		public String Name { get; set; }
		public String ClassName { get; set; }
		public Int32 CreationYear { get; set; }
		public TNation CreationNation { get; set; }
		public TNation PlayingNation { get; set; }
		public Int32 Level { get; set; }
		public Int32 Experience { get; set; }
		public Int32 RequiredCommandLevel { get; set; }
		public Int32 Width { get; private set; }
		public Int32 Length { get; private set; }
		public TBaseStorage Storage;
		public DoubleVariableBattleParameters BattleParameters;
		// Question about ship's cannons and cannonballs hasn't been solved yet
	}
	public enum ShipClass {
		BattleShip = 1,
		Frigate,
		Carvette,
		Galley,
		Trader,
		Sloop,
		FishingBoat
	}
	public enum TNation {
		England,
		Spain,
		Portugal,
		France,
		Brothers
	}
}
