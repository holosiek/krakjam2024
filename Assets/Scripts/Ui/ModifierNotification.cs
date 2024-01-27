using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifierNotification : MonoBehaviour
{
	[SerializeField]
	private float _displayInOutAnimationTime;
	
	[SerializeField]
	private float _displayTime;
	
	[SerializeField]
	private Image _modifierImage;
	
	[SerializeField]
	private TMP_Text _modifierText;

	[SerializeField]
	private CanvasGroup _notificationContainer;
	
	private Coroutine _notificationDisplay;
	
	public void ShowNotificaction(Modifier modifier)
	{
		if (_notificationDisplay != null)
		{
			StopCoroutine(_notificationDisplay);
		}
		_notificationDisplay = StartCoroutine(DisplayNotification());
		_modifierImage.sprite = modifier.Image;
		_modifierText.SetText(modifier.Text);
	}

	private IEnumerator DisplayNotification()
	{
		float inTimer = 0;
		float outTimer = 0;
		_notificationContainer.alpha = 0;
		
		while (inTimer < _displayInOutAnimationTime)
		{
			inTimer += Time.deltaTime;
			_notificationContainer.alpha = inTimer / _displayInOutAnimationTime;
			yield return null;
		}
		_notificationContainer.alpha = 1;

		yield return new WaitForSeconds(_displayTime);
		
		while (outTimer < _displayInOutAnimationTime)
		{
			outTimer += Time.deltaTime;
			_notificationContainer.alpha = (_displayInOutAnimationTime - outTimer) / _displayInOutAnimationTime;
			yield return null;
		}
		_notificationContainer.alpha = 0;

		_notificationDisplay = null;
	}
}
