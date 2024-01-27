using UnityEngine;

public class ModifierSystem : GameSystem
{
	[SerializeField]
	private Modifier _testModifier;
	
	public void ShowNotification()
	{
		GameInstance.Instance.Get<UiSystem>().ModifierNotification.ShowNotificaction(_testModifier);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			ShowNotification();
		}
	}
}
