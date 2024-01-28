using System;
using TMPro;
using UnityEngine;

public class BestTimes : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _bestTimesLabel;

	public void Start()
	{
		var timerSystem = GameInstance.Instance.Get<TimerSystem>();
		var dataSystem = GameInstance.Instance.Get<DataSystem>();
		dataSystem.AddNewBestTime(timerSystem.GetTime());
		var stryty = "Best times:\n";
		var list = dataSystem.BestTimes;
		for (int index = 0; index < list.Count; index++)
		{
			float time = list[index];
			stryty += (index+1) + ". " + timerSystem.GetReadableTime(time) + "\n";
		}

		_bestTimesLabel.SetText(stryty);
	}
}
