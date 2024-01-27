using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private Image _catGunImage;

    [SerializeField]
    private Image _pawsImage;

    public Image CatGunImage => _catGunImage;
    public Image PawsImage => _pawsImage;

    public void DeactivateAllImages()
    {
        CatGunImage.gameObject.SetActive(false);
        PawsImage.gameObject.SetActive(false);
    }
}
