using UnityEngine;
using System;

[System.Serializable]
class ParametersController: MonoBehaviour {
	public Parameters _parameters;

	public Parameters Parameters {
		get 
		{
			return _parameters;
		}
		set 
		{
			SetParameters(value);
		}
	}

	public ParametersController(Parameters parameters)
	{
		Parameters = parameters;
	}
	public ParametersController () {}

	/// <summary>
	/// Is virtual needed?
	/// </summary>
	/// <param name="parameters"></param>
	protected virtual void SetParameters(Parameters parameters)
	{
		AddArmour(parameters.Armour - this.Parameters.Armour);
		AddDraft(parameters.Draft - this.Parameters.Draft);
		AddHitPoints(parameters.HitPoints - this.Parameters.HitPoints);
		AddInitiative(parameters.Initiative - this.Parameters.Initiative);
		AddLuck(parameters.Luck - this.Parameters.Luck);
		AddMoral(parameters.Moral - this.Parameters.Moral);
		AddNumberOfGuns(parameters.NumberOfCannons - this.Parameters.NumberOfCannons);
		AddObservation(parameters.Observation - this.Parameters.Observation);
		AddSharpshooting(parameters.Sharpshooting - this.Parameters.Sharpshooting);
		AddSpeed(parameters.Speed - this.Parameters.Speed);
		AddSubtlety(parameters.Subtlety - this.Parameters.Subtlety);
		AddWeight(parameters.Weight - this.Parameters.Weight);
	}

	public virtual void AddObservation(int addition) {
		this._parameters.Observation += addition;
	}
	public virtual void AddSubtlety(int addition) {
		this._parameters.Subtlety += addition;
	}
	public virtual void AddArmour(ShipParts addition) {
		this._parameters.Armour += addition;
	}
	public virtual void AddHitPoints(ShipParts addition) {
		this._parameters.HitPoints += addition;
	}
	public virtual void AddNumberOfGuns(ShipParts addition) {
		this._parameters.NumberOfCannons += addition;
	}
	public virtual void AddSharpshooting(int addition) {
		this._parameters.Sharpshooting += addition;
	}
	public virtual void AddSpeed(float addition) {
		this._parameters.Speed += addition;
	}
	public virtual void AddDraft(int addition) {
		this._parameters.Draft += addition;
	}
	public virtual void AddWeight(int addition) {
		this._parameters.Weight += addition;
	}
	public virtual void AddLuck(int addition) {
		this._parameters.Luck += addition;
	}
	public virtual void AddMoral(int addition) {
		this._parameters.Moral += addition;
	}
	public virtual void AddInitiative(int addition) {
		this._parameters.Initiative += addition;
	}
}