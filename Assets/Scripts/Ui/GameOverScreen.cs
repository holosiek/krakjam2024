using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _gameOverScreen;

	[SerializeField] 
	private TMP_Text _timerLabel;

	public void ShowGameOverScreen()
	{
		var timerSystem = GameInstance.Instance.Get<TimerSystem>();
		float time = timerSystem.GetTime();
		_timerLabel.SetText(timerSystem.GetReadableTime(time));
		timerSystem.StopTimer();
		_gameOverScreen.alpha = 1;
	}
}
