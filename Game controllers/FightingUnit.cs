using System;
using System.Collections.Generic;
using UnityEngine;

abstract class FightingUnit: MonoBehaviour
{
    public UISlider slider;

    #region private fields
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _creationYear;
    [SerializeField]
    private Nation _creationNation;
    [SerializeField]
    private Nation _palyingNation;
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
    private CannonKind _cannonKind;
    [SerializeField]
    private CannonBallKind _cannonBallKind;
    #endregion

    #region properies
    public string Name
    {
        get { return _name; }
        protected set { _name = value; }
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
    public CannonKind CannonKind
    {
        get { return _cannonKind; }
        set { _cannonKind = value; }
    }
    public CannonBallKind CannonBallKind
    {
        get { return _cannonBallKind; }
        set { _cannonBallKind = value; }
    }
    public Cell CurrentCell
    {
        get { return _currentCell; }
        set
        {
            _currentCell.IsFree = true;
            _currentCell = value;
            _currentCell.IsFree = false;
        }
    }
    #endregion

    public FightingUnit(string name, int creationYear, Nation creationNation,
                Nation playingNation, int level, int experience, 
                Storage storage, BindedParametersController _base,
	            BalancingParametersController current, CannonKind cannonKind,
	            CannonBallKind cannonBallKind, Cell currentCell)
	{
		Name = name;
		CreationYear = creationYear;
		CreationNation = creationNation;
		PlayingNation = playingNation;
		Level = level;
		Experience = experience;
		Storage = storage;
		Base = _base;
		Current = current;
		CannonKind = cannonKind;
		CannonBallKind = cannonBallKind;
		CurrentCell = currentCell;
	}

    public void Awake()
    {
        Base.HPChanged += OnHPChanged;
        Current.HPChanged += OnHPChanged;
    }

    private void OnHPChanged(ParametersController obj)
    {
        slider.sliderValue = Current._parameters.HitPoints / Base._parameters.HitPoints;
        if (slider.sliderValue <= 0)
            Destroy(this, 100);
    }

    public IEnumerable<CannonBallKind> CannonBalls()
    {
        return (IEnumerable<CannonBallKind>)Storage.GetObjectsByType<CannonBallKind>();
    }

    public IEnumerable<CannonKind> Cannons()
    {
        return (IEnumerable<CannonKind>)Storage.GetObjectsByType<CannonKind>();
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode()
               ^ Enum.GetName(typeof(Nation), CreationNation).GetHashCode()
               ^ CreationYear;
    }

    public override bool Equals(object obj)
    {
        if (obj is FightingUnit)
            return Equals((FightingUnit)obj);
        return false;
    }

    public bool Equals(FightingUnit unit)
    {
        return this.Name == unit.Name &&
            this.CreationYear == unit.CreationYear &&
            this.CreationNation == unit.CreationNation;
    }

    public static bool operator ==(FightingUnit first, FightingUnit second)
    {
        return first.Equals(second);
    }

    public static bool operator !=(FightingUnit first, FightingUnit second)
    {
        return !(first == second);
    }

    public event Action<FightingUnit> TryingToSelect;
    public event Action<FightingUnit> Destroying;

    public void OnDestroy()
    {
        if (Destroying != null)
            Destroying(this);
    }

    public void OnMouseDown()
    {
        if (TryingToSelect != null)
            TryingToSelect(this);
    }
}

public enum Nation
{
    England,
    Spain,
    Portugal,
    France,
    Brothers
}