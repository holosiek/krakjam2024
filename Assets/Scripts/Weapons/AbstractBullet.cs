using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour
{
    [SerializeField]
    protected LayerMask _hitLayerMask;

    public abstract void Fire(Vector3 shootDirection);
}
