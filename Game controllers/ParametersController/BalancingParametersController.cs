[System.Serializable]
class BalancingParametersController : ParametersController {

	public BalancingParametersController (FightingUnitParameters parameters): base(parameters) {}

	private void UpdateParameters(FightingUnitParameters oldParameters) {
		//throw new System.NotImplementedException();
		///////////// TO DO /////////////
	}

    public override void AddArmour(float addition)
    {
		FightingUnitParameters oldParameters = _parameters;
		base.AddArmour(addition);
		UpdateParameters(oldParameters);
	}
    /*public override void AddDraft(int addition) {
        FightingUnitParameters oldParameters = _parameters;
        base.AddDraft(addition);
        UpdateParameters(oldParameters);
    }*/
    public override void AddHitPoints(float addition)
    {
        FightingUnitParameters oldParameters = _parameters;
		base.AddHitPoints(addition);
		UpdateParameters(oldParameters);
	}
	/*public override void AddInitiative(int addition) {
		Parameters oldParameters = _parameters;
		base.AddInitiative(addition);
		UpdateParameters(oldParameters);
	}*/
    public override void AddLuck(float addition)
    {
        FightingUnitParameters oldParameters = _parameters;
		base.AddLuck(addition);
		UpdateParameters(oldParameters);
	}
    public override void AddMoral(float addition)
    {
        FightingUnitParameters oldParameters = _parameters;
		base.AddMoral(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddNumberOfCannons(int addition) {
        FightingUnitParameters oldParameters = _parameters;
		base.AddNumberOfCannons(addition);
		UpdateParameters(oldParameters);
	}
	/*public override void AddObservation(int addition) {
		Parameters oldParameters = _parameters;
		base.AddObservation(addition);
		UpdateParameters(oldParameters);
	}*/
    public override void AddSharpshooting(float addition)
    {
        FightingUnitParameters oldParameters = _parameters;
		base.AddSharpshooting(addition);
		UpdateParameters(oldParameters);
	}
	/*public override void AddSpeed(float addition) {
        FightingUnitParameters oldParameters = _parameters;
		base.AddSpeed(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddSubtlety(int addition) {
		Parameters oldParameters = _parameters;
		base.AddSubtlety(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddWeight(int addition) {
		Parameters oldParameters = _parameters;
		base.AddWeight(addition);
		UpdateParameters(oldParameters);
	}*/
}