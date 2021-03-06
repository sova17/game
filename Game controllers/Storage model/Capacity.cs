using UnityEngine;

[System.Serializable]
class Capacity: MonoBehaviour {
    [SerializeField]
	private int weight;
    [SerializeField]
	private int space;

	public int Weight
	{
		get { return weight; }
		private set { weight = value; }
	}

	public int Space 
	{ 
		get { return space; }
		private set { space = value; }
	}
	
	public Capacity(int space, int weight) {
		this.Weight = weight;
		this.Space = space;
	}

	public static bool operator >(Capacity first, Capacity second) {
		return first.Space > second.Space || (first.Space == second.Space && first.Weight > second.Weight);
	}
	public static bool operator <(Capacity first, Capacity second) {
		return second > first;
	}
	public static Capacity operator -(Capacity first, Capacity second) {
		return new Capacity(first.Space - second.Space, first.Weight - second.Weight);
	}
	public static Capacity operator *(double mult, Capacity capacity) {
		return new Capacity((int)(capacity.Space * mult), (int)(capacity.Weight * mult));
	}
	public static Capacity operator +(Capacity first, Capacity second) {
		return new Capacity(first.Space + second.Space, first.Weight + second.Weight);
	}
	public static bool operator <(Capacity first, int num) {
		return first.Weight < num && first.Space < num;
	}
	public static bool operator >(Capacity first, int num) {
		return first.Weight > num && first.Space > num;
	}
}