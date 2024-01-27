using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private Image _catGunImage;

    [SerializeField]
    private Image _pawsImage;

    [SerializeField]
    private Image _catLaserImage;

    public Image CatGunImage => _catGunImage;
    public Image PawsImage => _pawsImage;
    public Image CatLaserImage => _catLaserImage;

    public void DeactivateAllImages()
    {
        CatGunImage.gameObject.SetActive(false);
        PawsImage.gameObject.SetActive(false);
        CatLaserImage.gameObject.SetActive(false);
    }
}
