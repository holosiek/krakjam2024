using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class InputSystem : GameSystem
{
	[SerializeField]
	private PlayerInput _playerInput;

	private InputSystemUIInputModule _inputModule;
	private PlayerInputActions _inputActionAsset;

	public PlayerInputActions PlayerInputAction => _inputActionAsset;

	public override void Initialize()
	{
		gameObject.AddComponent<EventSystem>();
		_inputModule = gameObject.AddComponent<InputSystemUIInputModule>();

		_inputActionAsset = new PlayerInputActions();
		_playerInput.actions = _inputActionAsset.asset;
		_inputModule.actionsAsset = _inputActionAsset.asset;
	}
}
