using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootingWeapon : ShootingWeapon
{
    [Header("Sprite Setup")]
    [SerializeField]
    private WeaponType _weaponType;

    [SerializeField]
    private float _shootingSpriteTime;

    [SerializeField]
    private List<Sprite> _idleSprites;

    [SerializeField]
    private List<Sprite> _shootingSprites;

    private CameraSystem _cameraSystem;
    private int _idleIndex = -1;
    private int _shootingIndex = -1;
    private Image _weaponImage;
    private Transform CameraTransform => _cameraSystem.MainCamera.transform;

    protected override void Start()
    {
        base.Start();
        _cameraSystem = FindAnyObjectByType<CameraSystem>();

        _weaponImage = _weaponType == WeaponType.CatGun
            ? GameInstance.UiSystem.WeaponHolder.CatGunImage
            : _weaponType == WeaponType.Paws
            ? GameInstance.UiSystem.WeaponHolder.PawsImage
            : GameInstance.UiSystem.WeaponHolder.CatGunImage;

        if (gameObject.activeInHierarchy)
        {
            GameInstance.UiSystem.WeaponHolder.DeactivateAllImages();
            UpdateSprite(GetNextIdleSprite());
            _weaponImage.gameObject.SetActive(true);
        }
    }

    private Sprite GetNextIdleSprite()
    {
        var nextIdle = _idleIndex + 1;
        _idleIndex = nextIdle >= _idleSprites.Count ? 0 : nextIdle;
        return _idleSprites[_idleIndex];
    }

    private Sprite GetNextShootingSprite()
    {
        var nextShooting = _shootingIndex + 1;
        _shootingIndex = nextShooting >= _shootingSprites.Count ? 0 : nextShooting;
        return _shootingSprites[_shootingIndex];
    }

    private void UpdateSprite(Sprite sprite)
    {
        _weaponImage.sprite = sprite;
    }

    protected override void SpawnBullet()
    {
        SpawnBullet(CameraTransform);
        _onShootActivable?.Activate();
        StopAllCoroutines();
        StartCoroutine(UpdateFireSprites());
    }

    private IEnumerator UpdateFireSprites()
    {
        UpdateSprite(GetNextShootingSprite());

        yield return new WaitForSeconds(_shootingSpriteTime);

        UpdateSprite(GetNextIdleSprite());
    }

    private enum WeaponType
    {
        CatGun,
        Paws
    }
}
