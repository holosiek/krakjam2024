using System;
using TMPro;
using UnityEngine;

public class TimerSystem : GameSystem
{
	[SerializeField]
	private TMP_Text _label;

	private float _time;
	private bool _shouldTimerWork = true;

	private string DoublePad(float num)
	{
		if (num < 10)
		{
			return "0" + (int)num;
		}

		return ((int)num).ToString();
	}

	public string GetReadableTime(float time)
	{
		return DoublePad(time/60) + ":" + DoublePad(time%60) + "." + DoublePad((time%1)*100);
	}
	
	public float GetTime()
	{
		return _time;
	}

	public void StopTimer()
	{
		_shouldTimerWork = false;
	}

	public void ResumeTimer()
	{
		_shouldTimerWork = true;
	}

	public void ResetTimer()
	{
		_time = 0;
		ResumeTimer();
	}
	
	public void Update()
	{
		if (_shouldTimerWork)
		{
			_time += Time.deltaTime;
			_label.SetText(GetReadableTime(_time));
		}
	}
}
