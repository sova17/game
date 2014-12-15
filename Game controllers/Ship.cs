using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
class Ship : FightingUnit//, IComparable<Ship>
{
    #region private fields
        [SerializeField]
        private ShipClass _className;
        [SerializeField]
        private int _width;
        [SerializeField]
        private int _length;
        [SerializeField]
        private int _requiredCommandLevel;
        [SerializeField]
        private IEnumerable<ShipPart> _shipParts;
    #endregion

    #region properies
	    public ShipClass ClassName
	    {
		    get { return _className; }
		    protected set { _className = value; }
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
        public int RequiredCommandLevel
        {
            get { return _requiredCommandLevel; }
            set { _requiredCommandLevel = value; }
        }
        public IEnumerable<ShipPart> ShipParts
        {
            get { return _shipParts; }
            set { _shipParts = value; }
        }
    #endregion

    public Ship(string name, ShipClass className, int creationYear,
                Nation creationNation, Nation playingNation, int level,
                int experience, int requiredCommandLevel, int width,
                int length, Storage storage, BindedParametersController _base,
                BalancingParametersController current, CannonKind cannonKind,
                CannonBallKind cannonBallKind, Cell currentCell):                   base(name, creationYear, creationNation,
                                                                                    playingNation, level, experience, storage,
                                                                                    _base, current, cannonKind, cannonBallKind,
                                                                                    currentCell)
    {
        ClassName = className;
        RequiredCommandLevel = requiredCommandLevel;
        Width = width;
        Length = length;
    }

	public override int GetHashCode() {
        return this.ClassName.GetHashCode() ^ base.GetHashCode();
	}

	public override bool Equals(object obj) {
		if (obj is Ship)
			return Equals((Ship)obj);
		return false;
	}

	public bool Equals(Ship ship) {
        return this.ClassName == ship.ClassName && base.Equals(ship);
	}

	public static bool operator ==(Ship first, Ship second) {
		return first.Equals(second);
	}

	public static bool operator !=(Ship first, Ship second) {
		return !(first == second);
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