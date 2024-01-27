﻿using System.Collections;
using UnityEngine;

public class ProjectileBullet : AbstractBullet
{
    [SerializeField]
    private float _damage = 20;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _lifetime;

    public override void Fire(Vector3 direction)
    {
        StartCoroutine(FireRoutine(direction));
    }

    private IEnumerator FireRoutine(Vector3 direction)
    {
        var currentTime = 0f;
        direction = transform.InverseTransformDirection(direction);
        var speedMultiplier = GameInstance.Instance.Get<MultipliersSystem>().BulletSpeedMultiplier;

        while (_lifetime / speedMultiplier > currentTime)
        {
            var deltaTime = Time.deltaTime;
            currentTime += deltaTime;
            transform.Translate(direction * _speed * deltaTime * speedMultiplier);
            CheckHit();
            yield return null;
        }

        Destroy(gameObject);
    }

    private void CheckHit()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var raycastHit, 0.4f, _hitLayerMask))
        {
            raycastHit.collider.GetComponent<HitBox>()?.DealDamage(_damage);
            Destroy(gameObject);
        }
    }
}
