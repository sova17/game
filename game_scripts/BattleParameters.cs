using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	class TBattleParameters {
		public Int32 Observation { get; protected set; }
		public Int32 Subtlety { get; protected set; }
		public ShipPartsScheme<Int32> Armour { get; protected set; }
		public ShipPartsScheme<Int32> HitPoInt32s { get; protected set; }
		public ShipPartsScheme<Int32> NumberOfGuns { get; protected set; }
		public Int32 Sharpshooting { get; protected set; }
		public Int32 Speed { get; protected set; }
		public Int32 Draft { get; protected set; }
		public Int32 Weight { get; protected set; }
		public Int32 Luck { get; protected set; }
		public Int32 Moral { get; protected set; }
		public Int32 Initiative { get; protected set; }
	}
	struct ShipPartsScheme<T> {
		public T HullLeft { get; private set; }
		public T HullRight { get; private set; }
		public T HullTail { get; private set; }
		public T HullHead { get; private set; }
		public T Deck { get; private set; }
		public T Mast { get; private set; }
	}
	abstract class TVariableBattleParameters : TBattleParameters {
		public void AddObservation(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddSubtlety(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddArmour(ShipPartsScheme<Int32> addition) {
			throw new NotImplementedException();
		}
		public void AddHitPoInt32s(ShipPartsScheme<Int32> addition) {
			throw new NotImplementedException();
		}
		public void AddNumberOfGuns(ShipPartsScheme<Int32> addition) {
			throw new NotImplementedException();
		}
		public void AddSharpshooting(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddSpeed(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddDraft(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddWeight(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddLuck(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddMoral(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddInitiative(Int32 addition) {
			throw new NotImplementedException();
		}
		public void AddBattleParameters(TBattleParameters param) {
			throw new NotImplementedException();
		}
	}	
	abstract class TBaseBalancingBattleVariableParameters : TVariableBattleParameters {
		public abstract void UpdateParameters();
	}
	class BindedVariableBattleParameters : TVariableBattleParameters {
		private TVariableBattleParameters targer;

	}
	class DoubleVariableBattleParameters {
		public TVariableBattleParameters Current { get; set; }
		public BindedVariableBattleParameters Full {get; private set;}
	}
}
