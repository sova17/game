using UnityEngine;

[System.Serializable]
class CannonKind : MonoBehaviour, IStorable {
	public string _name;
	public Capacity _capacity;
	public int _maxCannonballWeight;
	public float _sharpshooting;

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
	public float Sharpshooting 
	{
		get { return _sharpshooting; }
		set { _sharpshooting = value; }
	}

	public CannonKind(string name, Capacity capacity, int maxCannonballWeight, float sharpshooting) {
		this._name = name;
		this.Capacity = capacity;
		this.MaxCannonballWeight = maxCannonballWeight;
		this.Sharpshooting = sharpshooting;
	}
}