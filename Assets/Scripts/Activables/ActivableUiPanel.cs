using UnityEngine;

public class ActivableUiPanel : AbstractActivable
{
	[SerializeField]
	private BaseUiPanel _uiPanel;

	public override void Activate()
	{
		_uiPanel.Open();
	}

	public override void Deactivate()
	{
		_uiPanel.Close();
	}
}
