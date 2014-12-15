using UnityEngine;
using System;

[System.Serializable]
class Parameters: MonoBehaviour 
{
	public float Armour;
	public float HitPoints;
	public int LarboardNumberOfCannons;
	public int SarboardNumberOfCannons;
	public float Sharpshooting;
	public float Speed;
	public int DefaultStepLength;
	public float Luck;
	public float Moral;
	//public int Observation;
	//public int Subtlety;
	//public int Draft;
	//public int Weight;
	//public int Initiative;

	public static Parameters operator -(Parameters first, Parameters second) {
		Parameters result = new Parameters();
		result.Armour = first.Armour - second.Armour;
		result.HitPoints = first.HitPoints - second.HitPoints;
		result.LarboardNumberOfCannons = first.LarboardNumberOfCannons - second.LarboardNumberOfCannons;
		result.SarboardNumberOfCannons = first.SarboardNumberOfCannons - second.SarboardNumberOfCannons;
		result.Sharpshooting = first.Sharpshooting - second.Sharpshooting;
		result.Speed = first.Speed - second.Speed;
		result.Luck = first.Luck - second.Luck;
		result.Moral = first.Moral - second.Moral;
		//result.Observation = first.Observation - second.Observation;
		//result.Subtlety = first.Subtlety - second.Subtlety;
		//result.Draft = first.Draft - second.Draft;
		//result.Weight = first.Weight - second.Weight;
		//result.Initiative = first.Initiative - second.Initiative;
		return result;
	}
}