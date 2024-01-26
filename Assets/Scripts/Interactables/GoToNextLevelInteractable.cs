using System;
using UnityEngine;

public class GoToNextLevelInteractable : MonoBehaviour
{
	[SerializeField]
	private string _nextLevel;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameInstance.Instance.ChangeScene(_nextLevel);
		}
	}
}
