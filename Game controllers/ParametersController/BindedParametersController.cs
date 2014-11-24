[System.Serializable]
class BindedParametersController : ParametersController {
	public ParametersController _targetController;

	public BindedParametersController(ParametersController paramController) {
		this._targetController = paramController;
	}
	public override void AddArmour(int addition) {
		base.AddArmour(addition);
		_targetController.AddArmour(addition);
	}
	/*public override void AddDraft(int addition) {
		base.AddDraft(addition);
		_targetController.AddDraft(addition);
	}*/
	public override void AddHitPoints(int addition) {
		base.AddHitPoints(addition);
		_targetController.AddHitPoints(addition);
	}
	/*public override void AddInitiative(int addition) {
		base.AddInitiative(addition);
		_targetController.AddInitiative(addition);
	}*/
	public override void AddLuck(int addition) {
		base.AddLuck(addition);
		_targetController.AddLuck(addition);
	}
	public override void AddMoral(int addition) {
		base.AddMoral(addition);
		_targetController.AddMoral(addition);
	}
	public override void AddNumberOfLarboardCannons(int addition) {
		base.AddNumberOfLarboardCannons(addition);
		_targetController.AddNumberOfLarboardCannons(addition);
	}
    public override void AddNumberOfSarboardCannons(int addition)
    {
        base.AddNumberOfSarboardCannons(addition);
        _targetController.AddNumberOfSarboardCannons(addition);
    }
	/*public override void AddObservation(int addition) {
		base.AddObservation(addition);
		_targetController.AddObservation(addition);
	}*/
	public override void AddSharpshooting(int addition) {
		base.AddSharpshooting(addition);
		_targetController.AddSharpshooting(addition);
	}
	public override void AddSpeed(float addition) {
		base.AddSpeed(addition);
		_targetController.AddSpeed(addition);
	}
	/*public override void AddSubtlety(int addition) {
		base.AddSubtlety(addition);
		_targetController.AddSubtlety(addition);
	}
	public override void AddWeight(int addition) {
		base.AddWeight(addition);
		_targetController.AddWeight(addition);
	}*/
}
