using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ModifierSystem : GameSystem
{
	[SerializeField]
	private List<Modifier> _modifiersAvailable = new List<Modifier>();

	[SerializeField]
	private List<Modifier> _modifiersList = new List<Modifier>();

	public List<Modifier> ModifiersList => _modifiersList;
	
	public event Action<Modifier> OnModifierListUpdate;

	public void AddNewRandomModifier()
	{
		if (_modifiersAvailable.Count > 0)
		{
			
			int index = Random.Range(0, _modifiersAvailable.Count);
			var modifier = _modifiersAvailable[index];
			
			if (!_modifiersList.Contains(modifier))
			{
				_modifiersList.Add(modifier);
				OnModifierListUpdate?.Invoke(modifier);
				GameInstance.UiSystem.ModifierList.AddModifier(modifier);
				ShowNotification(modifier);
				_modifiersAvailable.RemoveAt(index);
			}
		}
	}

	public bool HasModifierTag(ModifierTag modifierTag)
	{
		foreach (var modifier in _modifiersList)
		{
			if (modifier.ModifierTag == modifierTag)
			{
				return true;
			}
		}

		return false;
	}
	
	public void ShowNotification(Modifier modifier)
	{
		GameInstance.UiSystem.ModifierNotification.ShowNotificaction(modifier);
	}

	public void RestartModifiers()
	{
		foreach (var modifier in _modifiersList)
		{
			_modifiersAvailable.Add(modifier);
		}
		
		_modifiersList.Clear();
		OnModifierListUpdate?.Invoke(null);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			AddNewRandomModifier();
		}
	}
}
