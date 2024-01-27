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

    protected virtual void Start()
    {
        _lastBulletTimeStamp = _timeStampBetweenBullets;
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

    protected virtual void SpawnBullet()
    {
        SpawnBullet(_muzzle);
    }

    protected void SpawnBullet(Transform bulletSource)
    {
        var bullet = Instantiate(_projectileBullet, bulletSource);
        bullet.transform.SetParent(null);
        bullet.Fire(bulletSource.forward);
    }
}
