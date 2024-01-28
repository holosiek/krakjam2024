using System.Collections.Generic;

public class DataSystem : GameSystem
{
	public List<float> BestTimes = new List<float>(){0,0,0,0,0,0,0,0,0,0};

	public void AddNewBestTime(float time)
	{
		bool wasAdded = false;
		
		for (int index = 0; index < BestTimes.Count; index++)
		{
			float bestTime = BestTimes[index];
			
			if (time < bestTime)
			{
				BestTimes.Insert(index, time);
				wasAdded = true;
				break;
			}
		}

		if (BestTimes.Count > 10)
		{
			BestTimes.RemoveAt(10);
		}
		else
		{
			if (!wasAdded)
			{
				BestTimes.Add(time);
			}
		}
	}
	
	public float GetBestTime()
	{
		if (BestTimes.Count == 0)
		{
			return 0;
		}
		return BestTimes[0];
	}
}
