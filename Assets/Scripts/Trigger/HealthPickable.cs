using UnityEngine;

public class HealthPickable : AbstractActivable
{
	[SerializeField]
	private float _healAmount;
	
	public override void Activate()
	{
		var healthManager = FindObjectOfType<CharacterController>().gameObject.GetComponentInChildren<HealthManager>();
		healthManager.AddHealth(_healAmount);
		gameObject.SetActive(false);
	}

	public override void Deactivate() { }
}
