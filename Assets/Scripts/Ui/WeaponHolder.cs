using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private Image _weaponImage;

    public void SetSprite(Sprite sprite)
    {
        _weaponImage.sprite = sprite;
    }
}
