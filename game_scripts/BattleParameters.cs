using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	struct TParameters {
		public Int32 Observation { get; set; }
		public Int32 Subtlety { get; set; }
		public ShipPartsScheme<Int32> Armour { get; set; }
		public ShipPartsScheme<Int32> HitPoints { get; set; }
		public ShipPartsScheme<Int32> NumberOfGuns { get; set; }
		public Int32 Sharpshooting { get; set; }
		public Int32 Speed { get; set; }
		public Int32 Draft { get; set; }
		public Int32 Weight { get; set; }
		public Int32 Luck { get; set; }
		public Int32 Moral { get; set; }
		public Int32 Initiative { get; set; }
	}
	struct ShipPartsScheme<T> {
		public T HullLeft { get; set; }
		public T HullRight { get; set; }
		public T HullTail { get; set; }
		public T HullHead { get; set; }
		public T Deck { get; set; }
		public T Mast { get; set; }
	}
	abstract class TBaseParametersController {
		public virtual TParameters Parameters { get; set; }
		public abstract void AddObservation(Int32 addition);
		public abstract void AddSubtlety(Int32 addition);
		public abstract void AddArmour(ShipPartsScheme<Int32> addition);
		public abstract void AddHitPoints(ShipPartsScheme<Int32> addition);
		public abstract void AddNumberOfGuns(ShipPartsScheme<Int32> addition);
		public abstract void AddSharpshooting(Int32 addition);
		public abstract void AddSpeed(Int32 addition);
		public abstract void AddDraft(Int32 addition);
		public abstract void AddWeight(Int32 addition);
		public abstract void AddLuck(Int32 addition);
		public abstract void AddMoral(Int32 addition);
		public abstract void AddInitiative(Int32 addition);
	}
	class TParametersController : TBaseParametersController { 
		private TParameters _parameters;
		public new TParameters Parameters {
			get {
				return _parameters;
			}
			set {
				//!!!!!!!!!!!! NOT RIGHT !!!!!!!!!!
				_parameters = value;
			}
		}
		public override void AddObservation(Int32 addition) {
			this._parameters.Observation += addition;
		}
		public override void AddSubtlety(Int32 addition) {
			this._parameters.Subtlety += addition;
		}
		public override void AddArmour(ShipPartsScheme<Int32> addition) {
			this._parameters.Armour += addition;
		}
		public override void AddHitPoints(ShipPartsScheme<Int32> addition) {
			this._parameters.HitPoints += addition;
		}
		public override void AddNumberOfGuns(ShipPartsScheme<int> addition) {
			this._parameters.NumberOfGuns += addition;
		}
		public override void AddSharpshooting(int addition) {
			this._parameters.Sharpshooting += addition;
		}
		public override void AddSpeed(int addition) {
			this._parameters.Speed += addition;
		}
		public override void AddDraft(int addition) {
			this._parameters.Draft += addition;
		}
		public override void AddWeight(int addition) {
			throw new NotImplementedException();
		}
		public override void AddLuck(int addition) {
			throw new NotImplementedException();
		}
		public override void AddMoral(int addition) {
			throw new NotImplementedException();
		}
		public override void AddInitiative(int addition) {
			throw new NotImplementedException();
		}
	}
	abstract class TBaseBalancingBattleVariableParameters {
		public abstract void UpdateParameters();
	}
	class BindedVariableBattleParameters {
		private TParameters targer;

	}
	class DoubleVariableBattleParameters {
		public TParameters Current { get; set; }
		public BindedVariableBattleParameters Full {get; private set;}
	}
}
