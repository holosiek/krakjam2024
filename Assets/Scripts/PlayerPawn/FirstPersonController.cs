using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour, PlayerInputActions.IGameplayActions
{
    [SerializeField]
    private Transform _playerRoot;

    [SerializeField]
    private Transform _cameraHolder;

    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private float _movementSpeed = 5f;

    [SerializeField]
    private float _sensitivity = 1f;

    private PlayerInputActions _inputActions;
    private InputSystem _inputSystem;
    private CameraSystem _cameraSystem;

    private Vector3 _currentLookInput = Vector3.zero;
    private Vector3 _currentMoveInput = Vector3.zero;
    private float _deltaTime;

    private Camera MainCamera => _cameraSystem.MainCamera;

    private void Start()
    {
        _inputSystem = FindAnyObjectByType<InputSystem>();
        _cameraSystem = FindAnyObjectByType<CameraSystem>();

        _inputActions = _inputSystem.PlayerInputAction;
        _inputActions.Gameplay.SetCallbacks(this);
        _inputActions.Gameplay.Enable();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _currentMoveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _currentLookInput = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {

    }

    private void Update()
    {
        _deltaTime = Time.deltaTime;
        MoveCharacter();
        RotateCharacter();
    }

    private void MoveCharacter()
    {
        var cameraRight = _cameraHolder.right;
        cameraRight.y = 0;

        var cameraForward = _cameraHolder.forward;
        cameraForward.y = 0;

        var desiredMoveInput = cameraForward * _currentMoveInput.y + cameraRight * _currentMoveInput.x;
        _characterController.Move(desiredMoveInput * _deltaTime * _movementSpeed);
    }

    private void RotateCharacter()
    {
        _cameraHolder.Rotate(Vector3.right * -_currentLookInput.y * _sensitivity * _deltaTime);
        _playerRoot.Rotate(Vector3.up * _currentLookInput.x * _sensitivity * _deltaTime);
    }
}
