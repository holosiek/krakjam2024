using UnityEngine;

public class PauseScreenUiPanel : BaseUiPanel
{
	private InputSystem _inputSystem;

	public override void Initialize()
	{
		_inputSystem = GameInstance.Instance.Get<InputSystem>();
	}

	protected override void InternalOnOpen()
	{
		Time.timeScale = 0;
		_inputSystem.PlayerInputAction.Gameplay.Disable();
		Cursor.lockState = CursorLockMode.None;
	}

	protected override void InternalOnClose()
	{
		_inputSystem.PlayerInputAction.Gameplay.Enable();
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1;
	}

	public override void Cleanup()
	{
		if (IsOpened)
		{
			_inputSystem.PlayerInputAction.Gameplay.Enable();
			Time.timeScale = 1;
			gameObject.SetActive(false);
		}
	}
}
