using UnityEngine;

public class PlayerPawn : MonoBehaviour, ISceneObject
{
	private PlayerHUDSystem PlayerHUD => GameInstance.UiSystem.PlayerHUDSystem;

	public void OnBeforeSceneReady()
	{
		PlayerHUD.SetActive(true);
	}

	public void OnBeforeSceneChange()
	{
		Cleanup();
	}

	private void Cleanup()
	{
		if (PlayerHUD != null)
		{
			PlayerHUD.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		Cleanup();
	}
}
