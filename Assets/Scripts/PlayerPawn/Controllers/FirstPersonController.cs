using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour, PlayerInputActions.IGameplayActions, ISceneObject
{
	[SerializeField]
	private Transform _playerRoot;

	[SerializeField]
	private Transform _cameraHolder;

	[SerializeField]
	private CharacterController _characterController;

	[SerializeField]
	private AbstractActivable _onJumpActivable;

	[SerializeField]
	private float _maxLookAngle = 60f;

	[SerializeField]
	private float _jumpForce = 50f;

	[SerializeField]
	private float _fallAcceleration = 1f;

	[SerializeField]
	private float _movementSpeed = 5f;

	[SerializeField]
	private float _sensitivity = 1f;

	private PlayerInputActions _inputActions;
	private InputSystem _inputSystem;

	private PawnWeaponController _weaponController;
	private MultipliersSystem _multipliersSystem;

	private Vector3 _currentJumpVelocity;
	private Vector3 _currentLookInput = Vector3.zero;
	private Vector3 _currentMoveInput = Vector3.zero;
	private float _deltaTime;

	private void Awake()
	{
		GatherComponents();
	}

	private void GatherComponents()
	{
		_weaponController = GetComponentInChildren<PawnWeaponController>();
	}

	public void OnSystemsInitialized()
	{
		_inputSystem = GameInstance.Instance.Get<InputSystem>();
		_multipliersSystem = GameInstance.Instance.Get<MultipliersSystem>();
		_inputActions = _inputSystem.PlayerInputAction;
		_inputActions.Gameplay.Disable();
	}

	public void OnAfterSceneReady()
	{
		_inputActions.Gameplay.SetCallbacks(this);
		_inputActions.Gameplay.Enable();
		Cursor.lockState = CursorLockMode.Locked;
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
		_weaponController.OnFireInput(context);
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed && _characterController.isGrounded)
		{
			_currentJumpVelocity = new Vector3(0, _jumpForce, 0);
			_onJumpActivable?.Activate();
		}
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
		var speedMultiplier = _deltaTime * _movementSpeed * _multipliersSystem.MovementSpeedMultiplier;
		_characterController.Move(desiredMoveInput * speedMultiplier);
		_characterController.Move(_currentJumpVelocity * _deltaTime * _multipliersSystem.MovementSpeedMultiplier);

		_currentJumpVelocity.y = Mathf.Clamp(
			_currentJumpVelocity.y - _fallAcceleration,
			Physics.gravity.y,
			_currentJumpVelocity.y);
	}

	private void RotateCharacter()
	{
		float xRotation = _cameraHolder.localRotation.eulerAngles.x;
		xRotation = xRotation > 180 ? xRotation - 360 : xRotation;

		var xDelta = _currentLookInput.y * _sensitivity * _deltaTime;
		xRotation = Mathf.Clamp(xRotation - xDelta, -_maxLookAngle, _maxLookAngle);

		_cameraHolder.localRotation = Quaternion.Euler(xRotation, _cameraHolder.localRotation.y, 0);
		_cameraHolder.Rotate(Vector3.right * -_currentLookInput.y * _sensitivity * _deltaTime);
		_playerRoot.Rotate(Vector3.up * _currentLookInput.x * _sensitivity * _deltaTime);
	}

	public void OnPreSceneChange()
	{
		Cleanup();
	}

	private void Cleanup()
	{
		_inputActions.Gameplay.Disable();
		_inputActions.Gameplay.RemoveCallbacks(this);
		_inputActions = null;
		_inputSystem = null;
		_multipliersSystem = null;
	}

	private void OnDestroy()
	{
		Cleanup();
	}
}
