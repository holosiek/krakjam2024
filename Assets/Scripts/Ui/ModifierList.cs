using System.Collections.Generic;
using UnityEngine;

public class ModifierList : MonoBehaviour
{
	[SerializeField]
	private ModifierListIcon _modifierListIcon;
	
	[SerializeField]
	private GameObject _modifierListContainer;

	private Dictionary<Modifier, ModifierListIcon> _modifierDictionary = new Dictionary<Modifier, ModifierListIcon>();
	
	public void AddModifier(Modifier modifier)
	{
		var modifierIcon = Instantiate(_modifierListIcon, _modifierListContainer.transform);
		_modifierDictionary.Add(modifier, modifierIcon);
		modifierIcon.SetIcon(modifier.Image);
	}

	public void ResetModifiers()
	{
		foreach (var pair in _modifierDictionary)
		{
			Destroy(pair.Value.gameObject);
		}
		_modifierDictionary.Clear();
	}
}
