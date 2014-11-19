using UnityEngine;
using System;

[System.Serializable]
class Parameters: MonoBehaviour {
	public int Observation;
	public int Subtlety;
	public ShipParts Armour;
	public ShipParts HitPoints;
	public ShipParts NumberOfCannons; //Guns???;
	public int Sharpshooting;
	public float Speed;
	public int Draft;
	public int Weight;
	public int Luck;
	public int Moral;
	public int Initiative;

	public static Parameters operator -(Parameters first, Parameters second) {
		Parameters result = new Parameters();
		result.Observation = first.Observation - second.Observation;
		result.Subtlety = first.Subtlety - second.Subtlety;
		result.Armour = first.Armour - second.Armour;
		result.HitPoints = first.HitPoints - second.HitPoints;
		result.NumberOfCannons = first.NumberOfCannons - second.NumberOfCannons;
		result.Sharpshooting = first.Sharpshooting - second.Sharpshooting;
		result.Speed = first.Speed - second.Speed;
		result.Draft = first.Draft - second.Draft;
		result.Weight = first.Weight - second.Weight;
		result.Luck = first.Luck - second.Luck;
		result.Moral = first.Moral - second.Moral;
		result.Initiative = first.Initiative - second.Initiative;
		return result;
	}
}