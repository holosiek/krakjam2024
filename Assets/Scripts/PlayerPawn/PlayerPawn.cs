using UnityEngine;

public class PlayerPawn : MonoBehaviour
{
	private PlayerHUDSystem PlayerHUD => GameInstance.UiSystem.PlayerHUDSystem;

	public void Start()
	{
		PlayerHUD.SetActive(true);
	}

	private void OnDestroy()
	{
		if (PlayerHUD != null)
		{
			PlayerHUD.SetActive(false);
		}
	}
}
