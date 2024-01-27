using UnityEngine;

public class RaycastBullet : AbstractBullet
{
    [SerializeField]
    private float _range;

    [SerializeField]
    private float _damage;

    public override void Fire(Vector3 shootDirection)
    {
        if (Physics.Raycast(transform.position, transform.forward, out var raycastHit, _range, _hitLayerMask))
        {
            raycastHit.collider.GetComponent<HitBox>()?.DealDamage(_damage);
            Destroy(gameObject);
        }
    }
}
