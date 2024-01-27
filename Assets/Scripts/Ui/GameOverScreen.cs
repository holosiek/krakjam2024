using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _gameOverScreen;

	public void ShowGameOverScreen()
	{
		_gameOverScreen.alpha = 1;
	}
}
