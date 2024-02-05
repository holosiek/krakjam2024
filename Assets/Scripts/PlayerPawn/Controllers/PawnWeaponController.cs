using UnityEngine;
using UnityEngine.InputSystem;

public class PawnWeaponController : MonoBehaviour
{
	[SerializeField]
	private ModifierTag _meowCatGunTag;

	[SerializeField]
	private ShootingWeapon _meowCatGun;

	[SerializeField]
	private ModifierTag _pawsWeaponTag;

	[SerializeField]
	private ShootingWeapon _pawsWeapon;

	[SerializeField]
	private ModifierTag _catLaserTag;

	[SerializeField]
	private ShootingWeapon _catLaserWeapon;

	[SerializeField]
	private ShootingWeapon _defaultWeapon;

	private ModifierSystem _modifierSystem;
	private ShootingWeapon _activeWeapon;

	private ShootingWeapon ActiveWeapon
	{
		get => _activeWeapon;
		set
		{
			if (_activeWeapon != value)
			{
				if (_activeWeapon != null)
				{
					_activeWeapon.gameObject.SetActive(false);
				}
				_activeWeapon = value;
				_activeWeapon.gameObject.SetActive(true);
			}
		}
	}

	private void Start()
	{
		OnModifierListUpdate(null);
		_modifierSystem = GameInstance.Instance.Get<ModifierSystem>();
		_modifierSystem.OnModifierListUpdate += OnModifierListUpdate;
	}

	private void OnModifierListUpdate(Modifier modifier)
	{
		if (GameInstance.Instance.Get<ModifierSystem>().HasModifierTag(_pawsWeaponTag))
		{
			ActiveWeapon = _pawsWeapon;
		}
		else if (GameInstance.Instance.Get<ModifierSystem>().HasModifierTag(_catLaserTag))
		{
			ActiveWeapon = _catLaserWeapon;
		}
		else
		{
			ActiveWeapon = _meowCatGun;
		}
	}

	public void OnFireInput(InputAction.CallbackContext context)
	{
		var triggerPhase = context.phase switch
		{
			InputActionPhase.Started => TriggerPhase.Started,
			InputActionPhase.Canceled => TriggerPhase.Released,
			_ => TriggerPhase.None
		};

		_activeWeapon.HandleInput(triggerPhase);
	}
}
