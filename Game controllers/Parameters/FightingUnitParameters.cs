using UnityEngine;

interface IFightingUnitParameters
{
    float Armour { get; set; }
    float HitPoints { get; set; }
    int ShootingRange { get; set; }
    int NumberOfCannons { get; set; }
    float Sharpshooting { get; set; }
    float Luck { get; set; }
    float Moral { get; set; }
}
[System.Serializable]
abstract class FightingUnitParameters : MonoBehaviour, IFightingUnitParameters
{
    #region private fields
    [SerializeField]
    private float _armour;
    [SerializeField]
    private float _hitPoints;
    [SerializeField]
    private int _shootingRange;
    [SerializeField]
    private int _numberOfCannons;
    [SerializeField]
    private float _sharpshooting;
    [SerializeField]
    private float _luck;
    [SerializeField]
    private float _moral;
    #endregion

    #region propertirs
    public float Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public float HitPoints
    {
        get { return _hitPoints; }
        set { _hitPoints = value; }
    }
    public int ShootingRange
    {
        get { return _shootingRange; }
        set { _shootingRange = value; }
    }
    public int NumberOfCannons
    {
        get { return _numberOfCannons; }
        set { _numberOfCannons = value; }
    }
    public float Sharpshooting
    {
        get { return _sharpshooting; }
        set { _sharpshooting = value; }
    }
    public float Luck
    {
        get { return _luck; }
        set { _luck = value; }
    }
    public float Moral
    {
        get { return _moral; }
        set { _moral = value; }
    }
    #endregion
}