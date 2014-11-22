using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
class Ship : MonoBehaviour, IComparable<Ship>
{
    #region private fields
        [SerializeField]
        private string _name;
        [SerializeField]
        private ShipClass _className;
        [SerializeField]
        private int _creationYear;
        [SerializeField]
        private Nation _creationNation;
        [SerializeField]
        private Nation _palyingNation;
        [SerializeField]
        private int _width;
        [SerializeField]
        private int _length;
        [SerializeField]
        private Storage _storage;
        [SerializeField]
        private BindedParametersController _base;
        [SerializeField]
        private BalancingParametersController _current;
        [SerializeField]
        private Cell _currentCell;
        [SerializeField]
        private int _level;
        [SerializeField]
        private int _experience;
        [SerializeField]
        private int _requiredCommandLevel;
        [SerializeField]
        private Cannon _cannonKind;
        [SerializeField]
        private CannonBall _cannonBallKind;
    #endregion

    #region properies
        public string Name
	    {
		    get { return _name; }
		    protected set { _name = value; }
	    }
	    public ShipClass ClassName
	    {
		    get { return _className; }
		    protected set { _className = value; }
	    }
	    public int CreationYear
	    {
		    get { return _creationYear; }
		    protected set { _creationYear = value; }
	    }
	    public Nation CreationNation
	    {
		    get { return _creationNation; }
		    protected set { _creationNation = value; }
	    }
        public Nation PlayingNation
        {
            get { return _palyingNation; }
            set { _palyingNation = value; }
        }
	    public int Width
	    {
		    get { return _width; }
		    protected set { _width = value; }
	    }
	    public int Length
	    {
		    get { return _length; }
		    protected set { _length = value; }
	    }
	    public Storage Storage
	    {
		    get { return _storage; }
		    protected set { _storage = value; }
	    }
	    public BindedParametersController Base
	    {
		    get { return _base; }
		    protected set { _base = value; }
	    }
	    public BalancingParametersController Current
	    {
		    get { return _current; }
		    protected set { _current = value; }
	    }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }
        public int RequiredCommandLevel
        {
            get { return _requiredCommandLevel; }
            set { _requiredCommandLevel = value; }
        }
        public Cannon CannonKind
        {
            get { return _cannonKind; }
            set { _cannonKind = value; }
        }
        public CannonBall CannonBallKind
        {
            get { return _cannonBallKind; }
            set { _cannonBallKind = value; }
        }
        public Cell CurrentCell
        {
            get { return _currentCell;  }
            set 
            {
                _currentCell.IsFree = true;
                _currentCell = value;
                _currentCell.IsFree = false;
            }
        }
    #endregion

    public Ship(string name, ShipClass className, int creationYear,
	            Nation creationNation, Nation playingNation, int level,
	            int experience, int requiredCommandLevel, int width, 
	            int length, Storage storage, BindedParametersController _base,
	            BalancingParametersController current, Cannon cannonKind,
	            CannonBall cannonBallKind, Cell currentCell)
	{
		Name = name;
		ClassName = className;
		CreationYear = creationYear;
		CreationNation = creationNation;
		PlayingNation = playingNation;
		Level = level;
		Experience = experience;
		RequiredCommandLevel = requiredCommandLevel;
		Width = width;
		Length = length;
		Storage = storage;
		Base = _base;
		Current = current;
		CannonKind = cannonKind;
		CannonBallKind = cannonBallKind;
		CurrentCell = currentCell;
	}

	public IEnumerable<CannonBall> CannonBalls() {
		return (IEnumerable<CannonBall>)Storage.GetObjectsByType<CannonBall>();
	}

	public IEnumerable<Cannon> Cannons() {
		return (IEnumerable<Cannon>)Storage.GetObjectsByType<Cannon>();
	}

	int IComparable<Ship>.CompareTo(Ship second) {
		if (Current.Parameters.Initiative > second.Current.Parameters.Initiative)
			return 1;
		if (Current.Parameters.Initiative < second.Current.Parameters.Initiative)
			return -1;
		System.Random rnd = new System.Random();
		return (rnd.NextDouble() > 0.5) ? 1 : -1;
	}

	public override int GetHashCode() {
		return this.ClassName.GetHashCode() 
			^ Name.GetHashCode() 
			^ Enum.GetName(typeof(Nation), CreationNation).GetHashCode() 
			^ CreationYear;
	}

	public override bool Equals(object obj) {
		if (obj is Ship)
			return Equals((Ship)obj);
		return false;
	}

	public bool Equals(Ship ship) {
		return this.Name == ship.Name &&
            this.ClassName == ship.ClassName &&
            this.CreationYear == ship.CreationYear &&
            this.CreationNation == ship.CreationNation;
	}

	public static bool operator ==(Ship first, Ship second) {
		return first.Equals(second);
	}

	public static bool operator !=(Ship first, Ship second) {
		return !(first == second);
	}

    public event Action<Ship> TryingToSelect;

    public void OnMouseDown()
    {
        if (TryingToSelect != null)
            TryingToSelect(this);
    }
}

public enum ShipClass 
{
	BattleShip,
	Frigate,
	Carvette,
	Galley,
	Trader,
	Sloop,
	FishingBoat
}

public enum Nation 
{
	England,
	Spain,
	Portugal,
	France,
	Brothers
}