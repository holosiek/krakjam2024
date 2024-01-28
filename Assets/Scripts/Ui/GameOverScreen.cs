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

    [SerializeField]
    private bool _allowToContinue;

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
        //_modifiersCollectedLabel.SetText(GameInstance.Instance.Get<ModifierSystem>().ModifiersList.Count.ToString());
        timerSystem.StopTimer();
        Time.timeScale = 0f;
        _gameOverScreen.alpha = 1;

        _inputSystem.PlayerInputAction.Additional.Enable();
        _inputSystem.PlayerInputAction.Additional.SetCallbacks(this);
    }

    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Cleanup();
            GameInstance.Instance.RestartGame();
        }
    }

    public void OnContinue(InputAction.CallbackContext context)
    {
        if (_allowToContinue && context.phase == InputActionPhase.Performed)
        {
            Cleanup();
            GameInstance.Instance.Continue();
        }
    }

    private void Cleanup()
    {
        _inputSystem.PlayerInputAction.Additional.Disable();
        _inputSystem.PlayerInputAction.Additional.RemoveCallbacks(this);
        Time.timeScale = 1f;
        _gameOverScreen.alpha = 0;
    }
}
