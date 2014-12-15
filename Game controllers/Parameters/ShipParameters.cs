using UnityEngine;

interface IShipParameters : IFightingUnitParameters
{
    float Speed { get; set; }
    int DefaultStepLength { get; set; }
}

[System.Serializable]
class ShipParameters : FightingUnitParameters, IShipParameters
{
    #region private fields
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _defaultStepLength;
    #endregion

    #region properties
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public int DefaultStepLength
    {
        get { return _defaultStepLength; }
        set { _defaultStepLength = value; }
    }
    #endregion

    public static ShipParameters operator -(ShipParameters first, ShipParameters second)
    {
        ShipParameters result = new ShipParameters();
        result.Armour = first.Armour - second.Armour;
        result.HitPoints = first.HitPoints - second.HitPoints;
        result.NumberOfCannons = first.NumberOfCannons - second.NumberOfCannons;
        result.Sharpshooting = first.Sharpshooting - second.Sharpshooting;
        result.Luck = first.Luck - second.Luck;
        result.Moral = first.Moral - second.Moral;
        result.Speed = first.Speed - second.Speed;
        result.DefaultStepLength = first.DefaultStepLength - second.DefaultStepLength;
        //result.Observation = first.Observation - second.Observation;
        //result.Subtlety = first.Subtlety - second.Subtlety;
        //result.Draft = first.Draft - second.Draft;
        //result.Weight = first.Weight - second.Weight;
        //result.Initiative = first.Initiative - second.Initiative;
        return result;
    }
}