using UnityEngine;

public class HitMarker : MonoBehaviour
{
	[SerializeField]
	private float _lifespan = 5;
	
	private float _time;
	
	public void Update()
	{
		_time += Time.deltaTime;
		
		if (_time >= _lifespan)
		{
			Destroy(gameObject);
		}
	}
}
