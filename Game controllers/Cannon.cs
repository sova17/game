using UnityEngine;

[System.Serializable]
class Cannon : MonoBehaviour, IStorable {
	public string _name;
	public Capacity _capacity;
	public int _maxCannonballWeight;
	public ShipParts _sharpshooting;

	public string Name 
	{
		get { return _name; }
	}
	public Capacity Capacity
	{ 
		get { return _capacity; }
		protected set { _capacity = value; } 
	}
	public int MaxCannonballWeight
	{
		get { return _maxCannonballWeight; }
		protected set { _maxCannonballWeight = value; }
	}
	public ShipParts Sharpshooting 
	{
		get { return _sharpshooting; }
		set { _sharpshooting = value; }
	}

	public Cannon(string name, Capacity capacity, int maxCannonballWeight, ShipParts sharpshooting) {
		this._name = name;
		this.Capacity = capacity;
		this.MaxCannonballWeight = maxCannonballWeight;
		this.Sharpshooting = sharpshooting;
	}
}