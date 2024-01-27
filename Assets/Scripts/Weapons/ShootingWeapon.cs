using UnityEngine;

public class ShootingWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzle;

    [SerializeField]
    private ProjectileBullet _projectileBullet;

    [SerializeField]
    [Min(0.1f)]
    private float _timeStampBetweenBullets = 0.2f;

    private bool _isHoldingTrigger;
    private float _lastBulletTimeStamp;

    private CameraSystem _cameraSystem;

    private void Start()
    {
        _lastBulletTimeStamp = _timeStampBetweenBullets;
        _cameraSystem = FindAnyObjectByType<CameraSystem>();
    }

    public void HandleInput(TriggerPhase triggerPhase)
    {
        if (triggerPhase == TriggerPhase.Started)
        {
            _isHoldingTrigger = true;
        }
        else if (triggerPhase == TriggerPhase.Released)
        {
            _isHoldingTrigger = false;
        }
    }

    private void Update()
    {
        _lastBulletTimeStamp += Time.deltaTime;

        if (_isHoldingTrigger && _lastBulletTimeStamp >= _timeStampBetweenBullets)
        {
            SpawnBullet();
            _lastBulletTimeStamp = 0f;
        }
    }

    private void SpawnBullet()
    {
        var bullet = Instantiate(_projectileBullet, _cameraSystem.MainCamera.transform);
        bullet.transform.SetParent(null);
        bullet.Fire(_cameraSystem.MainCamera.transform.forward);
    }
}
