using UnityEngine;

public class ModifierList : MonoBehaviour
{
	[SerializeField]
	private ModifierListIcon _modifierListIcon;
	
	[SerializeField]
	private GameObject _modifierListContainer;
	
	public void AddModifier(Modifier modifier)
	{
		var modifierIcon = Instantiate(_modifierListIcon, _modifierListContainer.transform);
		modifierIcon.SetIcon(modifier.Image);
	}
}
