using UnityEngine;
using UnityEngine.InputSystem;

public class PawnWeaponController : MonoBehaviour
{
    [SerializeField]
    private ShootingWeapon _shootingWeapon;

    public void OnFireInput(InputAction.CallbackContext context)
    {
        var triggerPhase = context.phase switch
        {
            InputActionPhase.Started => TriggerPhase.Started,
            InputActionPhase.Canceled => TriggerPhase.Released,
            _ => TriggerPhase.None
        };

        _shootingWeapon.HandleInput(triggerPhase);
    }

}
