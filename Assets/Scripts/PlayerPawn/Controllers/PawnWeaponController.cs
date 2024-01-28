using System;
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
                _activeWeapon?.gameObject.SetActive(false);
                _activeWeapon = value;
                _activeWeapon.gameObject.SetActive(true);
            }
        }
    }

    private void Start()
    {
        ActiveWeapon = _defaultWeapon;
        _modifierSystem = GameInstance.Instance.Get<ModifierSystem>();
        _modifierSystem.OnModifierListUpdate += OnModifierListUpdate;
    }

    private void OnModifierListUpdate(Modifier modifier)
    {
        if (modifier == null)
        {
            return;
        }
        
        if (modifier.ModifierTag == _pawsWeaponTag || GameInstance.Instance.Get<ModifierSystem>().HasModifierTag(_pawsWeaponTag))
        {
            ActiveWeapon = _pawsWeapon;
        }
        else if (modifier.ModifierTag == _meowCatGunTag || GameInstance.Instance.Get<ModifierSystem>().HasModifierTag(_meowCatGunTag))
        {
            ActiveWeapon = _meowCatGun;
        }
        else if (modifier.ModifierTag == _catLaserTag || GameInstance.Instance.Get<ModifierSystem>().HasModifierTag(_catLaserTag))
        {
            ActiveWeapon = _catLaserWeapon;
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
