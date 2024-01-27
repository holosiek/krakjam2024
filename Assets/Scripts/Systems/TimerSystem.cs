using System;
using TMPro;
using UnityEngine;

public class TimerSystem : GameSystem
{
	[SerializeField]
	private TMP_Text _label;

	private float _time;

	public void ResetTimer()
	{
		_time = 0;
	}

	private string DoublePad(float num)
	{
		if (num < 10)
		{
			return "0" + (int)num;
		}

		return ((int)num).ToString();
	}

	public string GetReadableTime()
	{
		return DoublePad(_time/60) + ":" + DoublePad(_time%60) + "." + DoublePad((_time%1)*100);
	}
	
	public void Update()
	{
		_time += Time.deltaTime;
		_label.SetText(GetReadableTime());
	}
}
