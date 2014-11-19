[System.Serializable]
class BalancingParametersController : ParametersController {

	public BalancingParametersController (Parameters parameters): base(parameters) {}

	public void UpdateParameters(Parameters oldParameters) {
		throw new System.NotImplementedException();
		///////////// TO DO /////////////
	}
	public override void AddArmour(ShipParts addition) {
		Parameters oldParameters = _parameters;
		base.AddArmour(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddDraft(int addition) {
		Parameters oldParameters = _parameters;
		base.AddDraft(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddHitPoints(ShipParts addition) {
		Parameters oldParameters = _parameters;
		base.AddHitPoints(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddInitiative(int addition) {
		Parameters oldParameters = _parameters;
		base.AddInitiative(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddLuck(int addition) {
		Parameters oldParameters = _parameters;
		base.AddLuck(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddMoral(int addition) {
		Parameters oldParameters = _parameters;
		base.AddMoral(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddNumberOfGuns(ShipParts addition) {
		Parameters oldParameters = _parameters;
		base.AddNumberOfGuns(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddObservation(int addition) {
		Parameters oldParameters = _parameters;
		base.AddObservation(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddSharpshooting(int addition) {
		Parameters oldParameters = _parameters;
		base.AddSharpshooting(addition);
		UpdateParameters(oldParameters);
	}
	public override void AddSpeed(float addition) {
		Parameters oldParameters = _parameters;
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
	}
}