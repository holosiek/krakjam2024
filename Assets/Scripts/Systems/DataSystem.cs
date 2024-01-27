using System.Collections.Generic;

public class DataSystem : GameSystem
{
	public List<float> BestTimes = new List<float>();

	public void AddNewBestTime(float time)
	{
		for (int index = 0; index < BestTimes.Count; index++)
		{
			float bestTime = BestTimes[index];
			
			if (time < bestTime)
			{
				BestTimes.Insert(index, time);
				break;
			}
		}

		if (BestTimes.Count > 10)
		{
			BestTimes.RemoveAt(10);
		}
	}
}
