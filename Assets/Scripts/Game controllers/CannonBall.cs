using UnityEngine;

[System.Serializable]
class CannonBall: MonoBehaviour, IStorable {
	public string _name;
	public Capacity _capacity;
	public int _airResistence;
	public ShipParts _damage;
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
	public int AirResistence
	{
		get { return _airResistence; }
		protected set { _airResistence = value; }
	}
	public ShipParts Damage
	{
		get { return _damage; }
		protected set { _damage = value; }
	}
	public ShipParts Sharpshooting
	{
		get { return _sharpshooting; }
		protected set { _sharpshooting = value; }
	}

	public CannonBall(string name, Capacity capacity, int airResistence, ShipParts damage, ShipParts sharpshooting) {
		this._name = name;
		this.Capacity = capacity;
		this.AirResistence = airResistence;
		this.Damage = damage;
		this.Sharpshooting = sharpshooting;
	}
}
