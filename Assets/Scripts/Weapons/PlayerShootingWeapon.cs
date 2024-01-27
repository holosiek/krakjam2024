using UnityEngine;

public class PlayerShootingWeapon : ShootingWeapon
{
    private CameraSystem _cameraSystem;

    private Transform CameraTransform => _cameraSystem.MainCamera.transform;

    protected override void Start()
    {
        base.Start();
        _cameraSystem = FindAnyObjectByType<CameraSystem>();
    }

    protected override void SpawnBullet()
    {
        SpawnBullet(CameraTransform);
    }
}
