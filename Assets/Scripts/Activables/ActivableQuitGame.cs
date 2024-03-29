using UnityEngine;

public class ActivableQuitGame : AbstractActivable
{
	public override void Activate()
	{
		Application.Quit();
	}

	public override void Deactivate()
	{

	}
}
