using UnityEngine;

public class UiSystem : GameSystem
{
	[SerializeField]
	private PlayerHUDSystem _playerHUDSystem;

	[SerializeField]
	private ModifierNotification _modifierNotification;

	[SerializeField]
	private ModifierList _modifierList;

	public PlayerHUDSystem PlayerHUDSystem => _playerHUDSystem;
	public ModifierNotification ModifierNotification => _modifierNotification;
	public ModifierList ModifierList => _modifierList;
}
