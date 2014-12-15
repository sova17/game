using UnityEngine;

interface IFortParameters : IFightingUnitParameters
{
    int Garrison { get; set; }
}

[System.Serializable]
class FortParameters : FightingUnitParameters, IFortParameters
{
    #region private fields
    [SerializeField]
    private int _garrison;
    #endregion

    #region properties
    public int Garrison
    {
        get { return _garrison; }
        set { _garrison = value; }
    }
    #endregion
    public static FortParameters operator -(FortParameters first, FortParameters second)
    {
        FortParameters result = new FortParameters();
        result.Armour = first.Armour - second.Armour;
        result.HitPoints = first.HitPoints - second.HitPoints;
        result.NumberOfCannons = first.NumberOfCannons - second.NumberOfCannons;
        result.Sharpshooting = first.Sharpshooting - second.Sharpshooting;
        result.Luck = first.Luck - second.Luck;
        result.Moral = first.Moral - second.Moral;
        //result.Observation = first.Observation - second.Observation;
        //result.Subtlety = first.Subtlety - second.Subtlety;
        //result.Draft = first.Draft - second.Draft;
        //result.Weight = first.Weight - second.Weight;
        //result.Initiative = first.Initiative - second.Initiative;
        return result;
    }
}