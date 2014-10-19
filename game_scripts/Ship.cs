using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseShip {
		public String Name { get; protected set; }
		public String ClassName { get; protected set; }
		public Int32 CreationYear { get; protected set; }
		public TNation CreationNation { get; protected set; }
		public TNation PlayingNation { get; set; }
		public Int32 Level { get; set; }
		public Int32 Experience { get; set; }
		public Int32 RequiredCommandLevel { get; set; }
		public Int32 Width { get; protected set; }
		public Int32 Length { get; protected set; }
		public TBaseStorage Storage { get; protected set; }
		public TBindedParametersController Base { get; protected set; }
		public TBalancingParametersController Current { get; protected set; }
		// Question about ship's cannonballs hasn't been solved yet
		public TCannon Cannons { get; set; }
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
