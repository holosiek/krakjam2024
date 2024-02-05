using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField]
	private Image _healthImg;

	[SerializeField]
	private float _width;

	public Image HealthImg => _healthImg;

	public void SetByPercent(float percent)
	{
		float reversedPercent = 1 - percent;
		HealthImg.rectTransform.offsetMax = new Vector2(-_width * reversedPercent, HealthImg.rectTransform.offsetMax.y);
	}
}
