using UnityEngine;
using System;

[System.Serializable]
class Parameters: MonoBehaviour {
	//public int Observation;
	//public int Subtlety;
    public int Armour;
    public int HitPoints;
    public int LarboardNumberOfCannons;
    public int SarboardNumberOfCannons;
    //public ShipParts Armour;
	//public ShipParts HitPoints;
	//public ShipParts NumberOfCannons;
	public int Sharpshooting;
	public float Speed;
    public int DefaultStepLength;
	//public int Draft;
	//public int Weight;
	public int Luck;
	public int Moral;
	//public int Initiative;

	public static Parameters operator -(Parameters first, Parameters second) {
		Parameters result = new Parameters();
		//result.Observation = first.Observation - second.Observation;
		//result.Subtlety = first.Subtlety - second.Subtlety;
		result.Armour = first.Armour - second.Armour;
		result.HitPoints = first.HitPoints - second.HitPoints;
        result.LarboardNumberOfCannons = first.LarboardNumberOfCannons - second.LarboardNumberOfCannons;
        result.SarboardNumberOfCannons = first.SarboardNumberOfCannons - second.SarboardNumberOfCannons;
		result.Sharpshooting = first.Sharpshooting - second.Sharpshooting;
		result.Speed = first.Speed - second.Speed;
		//result.Draft = first.Draft - second.Draft;
		//result.Weight = first.Weight - second.Weight;
		result.Luck = first.Luck - second.Luck;
		result.Moral = first.Moral - second.Moral;
		//result.Initiative = first.Initiative - second.Initiative;
		return result;
	}
}