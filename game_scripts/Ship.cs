using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	class TShip : IComparable<TShip> {
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
		public TCannon CannonKind { get; set; }
		public TCannonBall CannonBallKind { get; set; }
		public IEnumerable<TCannonBall> CannonBalls() {
			throw new NotImplementedException();
			///////////// TO DO /////////////
		}
		public IEnumerable<TCannon> Cannons() {
			throw new NotImplementedException();
			///////////// TO DO /////////////
		}
		public Int32 CompareTo(TShip second) {
			if (this.Current.Parameters.Initiative > second.Current.Parameters.Initiative)
				return 1;
			if (this.Current.Parameters.Initiative < second.Current.Parameters.Initiative)
				return -1;
			return 0;
		}
		public override Int32 GetHashCode() {
			return base.GetHashCode();
			///////////// TO DO /////////////
		}
		public override bool Equals(object obj) {
			return base.Equals(obj);
			///////////// TO DO /////////////
		}
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
