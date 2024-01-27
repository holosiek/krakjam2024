using System.Collections.Generic;
using UnityEngine;

public class ModifierSystem : GameSystem
{

	[SerializeField]
	private List<Modifier> _modifiersAvailable = new List<Modifier>();

	[SerializeField]
	private List<Modifier> _modifiersList = new List<Modifier>();

	public List<Modifier> ModifiersList => _modifiersList;

	public void AddNewRandomModifier()
	{
		if (_modifiersAvailable.Count > 0)
		{
			
			int index = Random.Range(0, _modifiersAvailable.Count);
			var modifier = _modifiersAvailable[index];
			
			if (!_modifiersList.Contains(modifier))
			{
				_modifiersList.Add(modifier);
				GameInstance.UiSystem.ModifierList.AddModifier(modifier);
				ShowNotification(modifier);
				_modifiersAvailable.RemoveAt(index);
			}
		}
	}
	
	public void ShowNotification(Modifier modifier)
	{
		GameInstance.UiSystem.ModifierNotification.ShowNotificaction(modifier);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			AddNewRandomModifier();
		}
	}
}
