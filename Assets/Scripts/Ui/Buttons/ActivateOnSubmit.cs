using UnityEngine;

public class ActivateOnSubmit : AbstractSubmitHandler
{
	[SerializeField]
	private AbstractActivable _activable;

	[SerializeField]
	private bool _shouldDeactivate;

	protected override void OnSubmit()
	{
		if (!_shouldDeactivate)
		{
			_activable.Activate();
		}
		else
		{
			_activable.Deactivate();
		}
	}
}
