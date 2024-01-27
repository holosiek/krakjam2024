using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField]
	private Image _healthImg;

	[SerializeField]
	private float _width;
	
	[SerializeField]
	[Range(0f, 1f)]
	private float _percent = 1f;
	
	public Image HealthImg => _healthImg;

	private float max = 1;

	public void OnValidate()
	{
		SetByPercent(_percent);
	}

	public void SetByPercent(float percent)
	{
		float reversedPercent = 1 - percent;
		Debug.Log(reversedPercent);
		HealthImg.rectTransform.offsetMax = new Vector2(-_width * reversedPercent, HealthImg.rectTransform.offsetMax.y);
	}
}
