using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour, PlayerInputActions.IAdditionalActions
{
    [SerializeField]
    private CanvasGroup _gameOverScreen;

    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = FindAnyObjectByType<InputSystem>();
    }

    public void ShowGameOverScreen()
    {
        _gameOverScreen.alpha = 1;
        _inputSystem.PlayerInputAction.Additional.Enable();
        _inputSystem.PlayerInputAction.Additional.SetCallbacks(this);
    }

    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _inputSystem.PlayerInputAction.Additional.Disable();
            _inputSystem.PlayerInputAction.Additional.RemoveCallbacks(this);
            GameInstance.Instance.ChangeScene(SceneManager.GetActiveScene().name);
            _gameOverScreen.alpha = 0;
        }
    }
}
