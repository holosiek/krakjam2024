using UnityEngine;
using UnityEngine.InputSystem;
﻿using TMPro;

public class GameOverScreen : MonoBehaviour, PlayerInputActions.IAdditionalActions
{
    [SerializeField]
    private TMP_Text _timerLabel;
    
    [SerializeField]
    private TMP_Text _bestTimeLabel;

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
        _bestTimeLabel.SetText(timerSystem.GetReadableTime(GameInstance.Instance.Get<DataSystem>().GetBestTime()));
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
