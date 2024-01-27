using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HitBox : MonoBehaviour
{
    [SerializeField]
    private HealthManager _healthManager;

    public void DealDamage(float damage)
    {
        _healthManager?.DecreaseHealth(damage);
    }
}
