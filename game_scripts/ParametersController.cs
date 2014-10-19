using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
		//abstract class TBaseParametersController {
	//	protected TParameters _parameters;
	//	public virtual TParameters Parameters { 
	//		get { 
	//			return _parameters; 
	//		}
	//		set {
	//			SetParameters(value);
	//		}
	//	}
	//	protected virtual void SetParameters(TParameters parameters) {
	//		throw new NotImplementedException();
	//	}
	//	public abstract void AddObservation(Int32 addition);
	//	public abstract void AddSubtlety(Int32 addition);
	//	public abstract void AddArmour(TShipParts addition);
	//	public abstract void AddHitPoints(TShipParts addition);
	//	public abstract void AddNumberOfGuns(TShipParts addition);
	//	public abstract void AddSharpshooting(Int32 addition);
	//	public abstract void AddSpeed(Int32 addition);
	//	public abstract void AddDraft(Int32 addition);
	//	public abstract void AddWeight(Int32 addition);
	//	public abstract void AddLuck(Int32 addition);
	//	public abstract void AddMoral(Int32 addition);
	//	public abstract void AddInitiative(Int32 addition);
	//}
	class TParametersController {
		protected TParameters _parameters;
		public TParameters Parameters {
			get {
				return _parameters;
			}
			set {
				SetParameters(value);
			}
		}
		protected virtual void SetParameters(TParameters parameters) {
			throw new NotImplementedException();
		}

		public virtual void AddObservation(Int32 addition) {
			this._parameters.Observation += addition;
		}
		public virtual void AddSubtlety(Int32 addition) {
			this._parameters.Subtlety += addition;
		}
		public virtual void AddArmour(TShipParts addition) {
			this._parameters.Armour += addition;
		}
		public virtual void AddHitPoints(TShipParts addition) {
			this._parameters.HitPoints += addition;
		}
		public virtual void AddNumberOfGuns(TShipParts addition) {
			this._parameters.NumberOfGuns += addition;
		}
		public virtual void AddSharpshooting(int addition) {
			this._parameters.Sharpshooting += addition;
		}
		public virtual void AddSpeed(int addition) {
			this._parameters.Speed += addition;
		}
		public virtual void AddDraft(int addition) {
			this._parameters.Draft += addition;
		}
		public virtual void AddWeight(int addition) {
			this._parameters.Weight += addition;
		}
		public virtual void AddLuck(int addition) {
			this._parameters.Luck += addition;
		}
		public virtual void AddMoral(int addition) {
			this._parameters.Moral += addition;
		}
		public virtual void AddInitiative(int addition) {
			this._parameters.Initiative += addition;
		}
	}
	class TBalancingParametersController : TParametersController {
		public void UpdateParameters(TParameters oldParameters) {
			throw new NotImplementedException();
		}
		public override void AddArmour(TShipParts addition) {
			TParameters oldParameters = _parameters;
			base.AddArmour(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddDraft(int addition) {
			TParameters oldParameters = _parameters;
			base.AddDraft(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddHitPoints(TShipParts addition) {
			TParameters oldParameters = _parameters;
			base.AddHitPoints(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddInitiative(int addition) {
			TParameters oldParameters = _parameters;
			base.AddInitiative(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddLuck(int addition) {
			TParameters oldParameters = _parameters;
			base.AddLuck(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddMoral(int addition) {
			TParameters oldParameters = _parameters;
			base.AddMoral(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddNumberOfGuns(TShipParts addition) {
			TParameters oldParameters = _parameters;
			base.AddNumberOfGuns(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddObservation(int addition) {
			TParameters oldParameters = _parameters;
			base.AddObservation(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddSharpshooting(int addition) {
			TParameters oldParameters = _parameters;
			base.AddSharpshooting(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddSpeed(int addition) {
			TParameters oldParameters = _parameters;
			base.AddSpeed(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddSubtlety(int addition) {
			TParameters oldParameters = _parameters;
			base.AddSubtlety(addition);
			UpdateParameters(oldParameters);
		}
		public override void AddWeight(int addition) {
			TParameters oldParameters = _parameters;
			base.AddWeight(addition);
			UpdateParameters(oldParameters);
		}
	}
	class TBindedParametersController : TParametersController {
		private TParametersController targetController;
		public TBindedParametersController(TParametersController paramController) {
			this.targetController = paramController;
		}
		public override void AddArmour(TShipParts addition) {
			base.AddArmour(addition);
			targetController.AddArmour(addition);
		}
		public override void AddDraft(int addition) {
			base.AddDraft(addition);
			targetController.AddDraft(addition);
		}
		public override void AddHitPoints(TShipParts addition) {
			base.AddHitPoints(addition);
			targetController.AddHitPoints(addition);
		}
		public override void AddInitiative(int addition) {
			base.AddInitiative(addition);
			targetController.AddInitiative(addition);
		}
		public override void AddLuck(int addition) {
			base.AddLuck(addition);
			targetController.AddLuck(addition);
		}
		public override void AddMoral(int addition) {
			base.AddMoral(addition);
			targetController.AddMoral(addition);
		}
		public override void AddNumberOfGuns(TShipParts addition) {
			base.AddNumberOfGuns(addition);
			targetController.AddNumberOfGuns(addition);
		}
		public override void AddObservation(int addition) {
			base.AddObservation(addition);
			targetController.AddObservation(addition);
		}
		public override void AddSharpshooting(int addition) {
			base.AddSharpshooting(addition);
			targetController.AddSharpshooting(addition);
		}
		public override void AddSpeed(int addition) {
			base.AddSpeed(addition);
			targetController.AddSpeed(addition);
		}
		public override void AddSubtlety(int addition) {
			base.AddSubtlety(addition);
			targetController.AddSubtlety(addition);
		}
		public override void AddWeight(int addition) {
			base.AddWeight(addition);
			targetController.AddWeight(addition);
		}
	}
}

