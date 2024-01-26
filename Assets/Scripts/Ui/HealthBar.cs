using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField]
	private Image _healthImg;

	public Image HealthImg => _healthImg;

	private float _width;

	private float max = 1;

	public void Awake()
	{
		_width = GetComponent<RectTransform>().rect.width;
	}

	public void SetByPercent(float percent)
	{
		float reversedPercent = 1 - percent;
		HealthImg.rectTransform.offsetMax = new Vector2(-_width * reversedPercent, HealthImg.rectTransform.offsetMax.y);
	}
}
