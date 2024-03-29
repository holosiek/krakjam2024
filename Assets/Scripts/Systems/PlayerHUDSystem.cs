using UnityEngine;

public class PlayerHUDSystem : GameSystem
{
	[SerializeField]
	private HealthBar _healthBar;

	[SerializeField]
	private WeaponHolder _weaponHolder;

	public HealthBar HealthBar => _healthBar;
	public WeaponHolder WeaponHolder => _weaponHolder;

	public void SetActive(bool active)
	{
		gameObject.SetActive(active);
	}
}
