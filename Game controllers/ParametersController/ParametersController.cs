using UnityEngine;
using System;

[System.Serializable]
class ParametersController: MonoBehaviour {
	public FightingUnitParameters _parameters;

	public FightingUnitParameters Parameters {
		get 
		{
			return _parameters;
		}
		set 
		{
			SetParameters(value);
		}
	}

    public event System.Action<ParametersController> HPChanged;

	public ParametersController(FightingUnitParameters parameters)
	{
		Parameters = parameters;
	}
	public ParametersController () {}

	/// <summary>
	/// Is virtual needed?
	/// </summary>
	/// <param name="parameters"></param>
	protected virtual void SetParameters(FightingUnitParameters parameters)
	{
		AddArmour(parameters.Armour - this.Parameters.Armour);
		AddHitPoints(parameters.HitPoints - this.Parameters.HitPoints);
		AddLuck(parameters.Luck - this.Parameters.Luck);
		AddMoral(parameters.Moral - this.Parameters.Moral);
		AddNumberOfCannons(parameters.NumberOfCannons - this.Parameters.NumberOfCannons);
		AddSharpshooting(parameters.Sharpshooting - this.Parameters.Sharpshooting);
		//AddSpeed(parameters.Speed - this.Parameters.Speed);
		//AddDraft(parameters.Draft - this.Parameters.Draft);
		//AddInitiative(parameters.Initiative - this.Parameters.Initiative);
		//AddObservation(parameters.Observation - this.Parameters.Observation);
		//AddSubtlety(parameters.Subtlety - this.Parameters.Subtlety);
		//AddWeight(parameters.Weight - this.Parameters.Weight);
	}

	/*public virtual void AddObservation(int addition) {
		this._parameters.Observation += addition;
	}
	public virtual void AddSubtlety(int addition) {
		this._parameters.Subtlety += addition;
	}*/
    public virtual void AddArmour(float addition)
    {
		this._parameters.Armour += addition;
	}
    public virtual void AddHitPoints(float addition)
    {
		this._parameters.HitPoints += addition;
        if (HPChanged != null)
            HPChanged(this);
	}
	public virtual void AddNumberOfCannons(int addition) {
		this._parameters.NumberOfCannons += addition;
	}
    public virtual void AddSharpshooting(float addition)
    {
		this._parameters.Sharpshooting += addition;
	}
	/*public virtual void AddSpeed(float addition) {
		this._parameters.Speed += addition;
	}
	public virtual void AddDraft(int addition) {
		this._parameters.Draft += addition;
	}
	public virtual void AddWeight(int addition) {
		this._parameters.Weight += addition;
	}*/
    public virtual void AddLuck(float addition)
    {
		this._parameters.Luck += addition;
	}
    public virtual void AddMoral(float addition)
    {
		this._parameters.Moral += addition;
	}/*
	public virtual void AddInitiative(int addition) {
		this._parameters.Initiative += addition;
	}*/
}