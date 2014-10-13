using System;
using System.IO;

namespace game_scripts {
	class Program {
		static void Main(string[] args) {
		}
	}
}
namespace game_scripts {
	public class TCell {
		public int X { get; set; }
		public int Y { get; set; }
		public int Depth { get; set; }
		public TSpecificators BonusSpecificators { get; set; }
	}

	class CannonBall {
		public int Weight { get; set; }
		public int AirResistant { get; set; }
		public int HullHeadDamage { get; set; }
		public int HullTailDamage { get; set; }
		public int HullLeftDamage { get; set; }
		public int HullRightDamage { get; set; }
		public int MastDamage { get; set; }
		public int HullHeadSharpshooting { get; set; }
		public int HullTailSharpshooting { get; set; }
		public int HullLeftSharpshooting { get; set; }
		public int HullRightSharpshooting { get; set; }
		public int MastSharpshooting { get; set; }
		public int AirSharpshooting { get; set; }
	}
	class Cannon {
		public int Weight { get; set; }
		public int MaxCanonBallWeight { get; set; }
		public int HullHeadSharpshooting { get; set; }
		public int HullTailSharpshooting { get; set; } 
		public int HullLeftSharpshooting { get; set; }
		public int HullRightSharpshooting { get; set; } 
		public int MastSharpshooting { get; set; }
		public int AirSharpshooting { get; set; }
	}
	class TShip {
		ShipClass _class; 
		public String Name { get; private set; }
		public String ClassName { get { return Enum.GetName(_class.GetType(), _class); } private set { _class = (ShipClass)Enum.Parse(_class.GetType(), value); } }
		public Nation CreationNation { get; private set; }
		public int CreationYear { get; private set; }
		public Nation PlayingNation { get; set; }
		public int Level { get; set; }
		public int Experience { get; set; }
		public int RequiredCommanderLevel { get; private set; }
		public Cannon Canons { get; set; }
	
		public ShipConfigurationSpecificators Specificators;
	}
	class ShipConfigurationSpecificators {

		#region constant (dimensional) configuration
	
		#endregion
	
	}

	public class VariableSpecificators : TSpecificators {
	public void Update() {
		throw new NotImplementedException();	
	}
	public override void AddObservation(int addition) {
		base.AddObservation(addition);
		Update();
	}
	public override void AddSubtlety(int addition) {
		base.AddSubtlety(addition);
		Update();
	}
	public override void AddArmour(TArmour addition) {
		base.AddArmour(addition);
		Update();
	}
	public override void AddHitPoints(THitPoints addition) {
		base.AddHitPoints(addition);
		Update();
	}
	public override void AddNumberOfGuns(TNumberOfGuns addition) {
		base.AddNumberOfGuns(addition);
		Update();
	}
	public override void AddSharpshooting(int addition) {
		base.AddSharpshooting(addition);
		Update();
	}
	public override void AddSpeed(int addition) {
		base.AddSpeed(addition);
		Update();
	}
	public override void AddDimensions(TSpecificators.TDimesions addition) {
		base.AddDimensions(addition);
		Update();
	}
	public override void AddSpirital(TSpecificators.TSpirital addition) {
		base.AddSpirital(addition);
		Update();
	}
}
	public class TSpecificators {
		public TSpecificators DeepCopy() {
			TSpecificators spec = new TSpecificators();
			spec.Observation = this.Observation;
			spec.Subtlety = this.Subtlety;
			spec.Armour = this.Armour;
			spec.HitPoints = this.HitPoints;
			spec.NumberOfGuns = this.NumberOfGuns;
			spec.Sharpshooting = this.Sharpshooting;
			spec.Speed = this.Speed;
			spec.Dimensions = this.Dimensions;
			spec.Spirital = this.Spirital;
			return spec;
		}
		public int Observation { get; private set; }
		public int Subtlety { get; private set; }
		public TArmour Armour { get; private set; }
		public THitPoints HitPoints { get; private set; }
		public TNumberOfGuns NumberOfGuns { get; private set; }
		public int Sharpshooting { get; private set; }
		public int Speed { get; private set; }
		public TDimesions Dimensions { get; private set; }
		public TSpirital Spirital { get; private set; }
		
		#region Add methods
		public virtual void AddObservation(int addition) {
			Observation += addition;
		}
		public virtual void AddSubtlety (int addition) {
			Subtlety += addition;
		}
		public virtual void AddArmour(TArmour addition) {
			Armour += addition;
		}
		public virtual void AddHitPoints(THitPoints addition) {
			HitPoints += addition;
		}
		public virtual void AddNumberOfGuns(TNumberOfGuns addition) {
			NumberOfGuns += addition;
		}
		public virtual void AddSharpshooting(int addition) {
			Sharpshooting += addition;
		}
		public virtual void AddSpeed(int addition) {
			Speed += addition;
		}
		public virtual void AddDimensions(TDimesions addition) {
			Dimensions += addition;
		}
		public virtual void AddSpirital(TSpirital addition) {
			Spirital += addition;
		}
		#endregion

		#region structs
		public struct TDimesions {
			public int Width { get; private set; }
			public int Length { get; private set; }
			public int Draft { get; set; }
			public int Weight { get; private set; }
			public int BearingCapacity { get; set; }
			public static TDimesions operator +(TDimesions first, TDimesions second) {
				throw new NotImplementedException();
			}
		}
		public struct THitPoints {
			public int HullLeft { get; set; }
			public int HullRight { get; set; }
			public int HullHead { get; set; }
			public int HullTail { get; set; }
			public int Mast { get; set; }
			public static THitPoints operator +(THitPoints first, THitPoints second) {
				throw new NotImplementedException();
			}
		}
		public struct TSpirital {
			public int Luck { get; set; }
			public int Initiative { get; set; }
			public int Moral { get; set; }
			public static TSpirital operator +(TSpirital first, TSpirital second) {
				throw new NotImplementedException();
			}
		}
		public struct TNumberOfGuns {
			public int HullLeft { get; set; }
			public int HullRight { get; set; }
			public int HullHead { get; set; }
			public int HullTail { get; set; }
			public int Deck { get; set; }
			public static TNumberOfGuns operator +(TNumberOfGuns first, TNumberOfGuns second) {
				throw new NotImplementedException();
			}
		}
		public struct TArmour {
			public int HullLeft { get; set; }
			public int HullRight { get; set; }
			public int HullHead { get; set; }
			public int HullTail { get; set; }
			public int Deck { get; set; }
			public static TArmour operator +(TArmour first, TArmour second) {
				throw new NotImplementedException();
			}
		}
		#endregion
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

	public enum Nation {
		England,
		Spain,
		Portugal,
		France,
		Brothers
	}
}
		//#region hit points
		//public int HullLeftHitpoints {
		//	get { return currentSpecs.HullLeftHitpoints; }
		//	set {
		//		TSpecificators oldSpecs = currentSpecs;
		//		currentSpecs.HullLeftHitpoints = value;
		//		UpdateNumberOfGunsLeft(oldSpecs);
		//		UpdateMoral(oldSpecs);
		//	}
		//}
		//public int HullRightHitpoints {
		//	get { return currentSpecs.HullRightHitpoints; }
		//	set {
		//		TSpecificators oldSpecs = currentSpecs;
		//		currentSpecs.HullRightHitpoints = value;
		//		UpdateNumberOfGunsRight(oldSpecs);
		//		UpdateMoral(oldSpecs);
		//	}
		//}
		//public int HullHeadHitpoints {
		//	get { return currentSpecs.HullHeadHitpoints; }
		//	set {
		//		TSpecificators oldSpecs = currentSpecs;
		//		currentSpecs.HullHeadHitpoints = value;
		//		UpdateNumberOfGunsHead(oldSpecs);
		//		UpdateMoral(oldSpecs);

		//	}
		//}
		//public int HullTailHitpoints {
		//	get { return currentSpecs.HullTailHitpoints; }
		//	set {
		//		TSpecificators oldSpecs = currentSpecs;
		//		currentSpecs.HullTailHitpoints = value;
		//		UpdateNumberOfGunsTail(oldSpecs);
		//		UpdateMoral(oldSpecs);
		//	}
		//}
		//public int MastHitpoints {
		//	get { return currentSpecs.MastHitpoints; }
		//	set {
		//		TSpecificators oldSpecs = currentSpecs;
		//		currentSpecs.MastHitpoints = value;
		//		UpdateNumberOfGunsAir(oldSpecs);
		//		UpdateMoral(oldSpecs);
		//	}
		//}
	//}
		//public int BearingCapacity {
		//	get { return currentSpecs.BearingCapacity; }
		//	set {
		//		if (value != this.BearingCapacity) {
		//			TSpecificators oldSpecs = currentSpecs;
		//			currentSpecs.BearingCapacity = value;
		//			UpdateDraft(oldSpecs);
		//			UpdateSpeed(oldSpecs);
		//		}
		//	}
		//}
		//public int Speed {
		//	get { return currentSpecs.Speed; }
		//	set {
		//		if (value != this.Speed) {
		//			TSpecificators oldSpecs = currentSpecs;
		//			currentSpecs.Speed = value;
		//			UpdateInitiative(oldSpecs);
		//		}
		//	}
		//}
		//public int Moral {
		//	get { return currentSpecs.Moral; }
		//	set {
		//		if (value != this.Moral) {
		//			TSpecificators oldSpecs = currentSpecs;
		//			currentSpecs.Moral = value;
		//			UpdateSpeed(oldSpecs);
		//			UpdateSharpshooting(oldSpecs);
		//			UpdateSubtlety(oldSpecs);
		//			UpdateObservation(oldSpecs);
		//			//UpdateInitiative(oldSpecs);
		//		}
		//	}
		//}

		//#endregion

		//#endregion
	//#region update methods
		//#region dependent
		//private void UpdateSpeed(TSpecificators oldSpecs) {
		//	UpdateInitiative(oldSpecs);
		//	throw new NotImplementedException();
		//}
		//private void UpdateMoral(TSpecificators oldSpecs) {
		//	UpdateSpeed(new TSpecificators());
		//	UpdateSharpshooting(oldSpecs);
		//	UpdateSubtlety(oldSpecs);
		//	UpdateObservation(oldSpecs);
		//	//UpdateInitiative(oldSpecs);
		//	throw new NotImplementedException();
		//}
		//#endregion
