using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
﻿using TMPro;

public class GameOverScreen : MonoBehaviour, PlayerInputActions.IAdditionalActions
{
    [SerializeField]
    private TMP_Text _timerLabel;

    [SerializeField]
    private CanvasGroup _gameOverScreen;

    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = FindAnyObjectByType<InputSystem>();
    }

    public void ShowGameOverScreen()
    {
        var timerSystem = GameInstance.Instance.Get<TimerSystem>();
        float time = timerSystem.GetTime();
        _timerLabel.SetText(timerSystem.GetReadableTime(time));
        timerSystem.StopTimer();
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
            _gameOverScreen.alpha = 0;
            GameInstance.Instance.RestartGame();
        }
    }
}
