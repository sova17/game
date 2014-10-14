using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseShip {
		public String Name { get; set; }
		public String ClassName { get; set; }
		public int CreationYear { get; set; }
		public TNation CreationNation { get; set; }
		public TNation PlayingNation { get; set; }
		public int Level { get; set; }
		public int Experience { get; set; }
		public int RequiredCommandLevel { get; set; }
		public int Width { get; private set; }
		public int Length { get; private set; }
		public int Weight { get; private set; }
		//
		// Пушки и груз!!!!
		//
		public int Observation { get; private set; }
		public int Subtlety { get; private set; }
		public PartsScheme<int> Armour { get; private set; }
		public PartsScheme<int> HitPoints { get; private set; }
		public PartsScheme<int> NumberOfGuns { get; private set; }
		public int Sharpshooting { get; private set; }
		public int Speed { get; private set; }
		public TDimesions Dimensions { get; private set; }
		public int Luck { get; set; }
		public int Moral { get; set; }
		public int Initiative { get; set; }
	}
	public class PartsScheme<T> {
		public T HullLeft { get; set; }
		public T HullRight { get; set; }
		public T HullTail { get; set; }
		public T HullHead { get; set; }
		public T Deck { get; set; }
		public T Mast { get; set; }
	}
	public class TDimesions {
		public int Draft { get; set; }
		public int BearingCapacity { get; set; }
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
