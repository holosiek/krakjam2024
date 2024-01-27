using UnityEngine;
using UnityEngine.UI;

public class ModifierListIcon : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	public void SetIcon(Sprite sprite)
	{
		_icon.sprite = sprite;
	}
}
