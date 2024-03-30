using UnityEngine;

public class UiSystem : GameSystem
{
	[SerializeField]
	private PlayerHUDSystem _playerHUDSystem;

	[SerializeField]
	private ModifierNotification _modifierNotification;

	[SerializeField]
	private ModifierList _modifierList;

	[SerializeField]
	private PauseScreenUiPanel _pauseScreenUiPanel;

	public PlayerHUDSystem PlayerHUDSystem => _playerHUDSystem;
	public ModifierNotification ModifierNotification => _modifierNotification;
	public ModifierList ModifierList => _modifierList;
	public PauseScreenUiPanel PauseScreenUiPanel => _pauseScreenUiPanel;

	public override void OnNewSceneInitialized()
	{
		_pauseScreenUiPanel.Initialize();
	}

	public override void OnPreSceneChange()
	{
		_pauseScreenUiPanel.Cleanup();
	}
}
