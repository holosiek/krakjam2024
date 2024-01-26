using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInputActions;

public class FirstPersonController : MonoBehaviour, IGameplayActions
{
    [SerializeField]
    private CharacterController _characterController;

    private PlayerInputActions _inputActions;
    private InputSystem _inputSystem;

    private void Start()
    {
        _inputSystem = FindAnyObjectByType<InputSystem>();
        _inputActions = _inputSystem.PlayerInputAction;
        _inputActions.Gameplay.SetCallbacks(this);
        _inputActions.Gameplay.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("SexMove");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("SexLook");
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("SexFire");
    }
}
