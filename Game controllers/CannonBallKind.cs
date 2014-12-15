using UnityEngine;

[System.Serializable]
class CannonBallKind: MonoBehaviour, IStorable {
	public string _name;
	public Capacity _capacity;
	public int _airResistence;
	public float _damage;
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
	public int AirResistence
	{
		get { return _airResistence; }
		protected set { _airResistence = value; }
	}
	public float Damage
	{
		get { return _damage; }
		protected set { _damage = value; }
	}
	public float Sharpshooting
	{
		get { return _sharpshooting; }
		protected set { _sharpshooting = value; }
	}

	public CannonBallKind(string name, Capacity capacity, int airResistence, float damage, float sharpshooting) {
		this._name = name;
		this.Capacity = capacity;
		this.AirResistence = airResistence;
		this.Damage = damage;
		this.Sharpshooting = sharpshooting;
	}
}
