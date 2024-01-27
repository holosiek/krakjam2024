using System.Collections.Generic;
using UnityEngine;

public class ModifierSystem : GameSystem
{
	[SerializeField]
	private Modifier _testModifier;

	[SerializeField]
	private List<Modifier> _modifiersList = new List<Modifier>();

	public List<Modifier> ModifiersList => _modifiersList;
	
	public void ShowNotification()
	{
		if (!_modifiersList.Contains(_testModifier))
		{
			_modifiersList.Add(_testModifier);
			GameInstance.UiSystem.ModifierNotification.ShowNotificaction(_testModifier);
			GameInstance.UiSystem.ModifierList.AddModifier(_testModifier);
		}
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			ShowNotification();
		}
	}
}
