using UnityEngine;
using UnityEngine.InputSystem;

public class UiSystem : GameSystem
{
	[SerializeField]
	public HealthBar HealthBar;

	[SerializeField]
	public ModifierNotification ModifierNotification;

	[SerializeField]
	public ModifierList ModifierList;

	[SerializeField]
	public GameOverScreen GameOverScreen;

	[SerializeField]
	public GameOverScreen GameWinScreen;
	
	[SerializeField]
	public GameOverScreen GameCompletedScreen;

	[SerializeField]
	public WeaponHolder WeaponHolder;
}
