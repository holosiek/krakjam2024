using UnityEngine;
using UnityEngine.InputSystem;

public class OtherUiInputController : MonoBehaviour, ISceneObject, PlayerInputActions.IOtherUiActions
{
	private PlayerInputActions _inputActions;
	private InputSystem _inputSystem;
	private PauseScreenUiPanel _pauseScreenUiPanel;
	public void OnSystemsInitialized()
	{
		_inputSystem = GameInstance.Instance.Get<InputSystem>();
		_inputActions = _inputSystem.PlayerInputAction;
		_pauseScreenUiPanel = GameInstance.UiSystem.PauseScreenUiPanel;
		_inputActions.OtherUi.Disable();
	}

	public void OnAfterSceneReady()
	{
		_inputActions.OtherUi.SetCallbacks(this);
		_inputActions.OtherUi.Enable();
	}

	public void OnTogglePause(InputAction.CallbackContext context)
	{
		if (_pauseScreenUiPanel.IsOpened)
		{
			_pauseScreenUiPanel.Close();
		}
		else
		{
			_pauseScreenUiPanel.Open();
		}
	}

	public void OnPreSceneTearDown()
	{
		if (_inputActions != null)
		{
			_inputActions.OtherUi.RemoveCallbacks(this);
			_inputActions.OtherUi.Disable();
		}

		_inputSystem = null;
	}
}
