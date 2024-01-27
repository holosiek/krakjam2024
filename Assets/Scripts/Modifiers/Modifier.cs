using UnityEngine;

[CreateAssetMenu(fileName = "Modifier", menuName = "ScriptableObjects/Modifier", order = 1)]
public class Modifier : ScriptableObject
{
	public ModifierTag ModifierTag;
	public Sprite Image; 
	public string Text;
}
