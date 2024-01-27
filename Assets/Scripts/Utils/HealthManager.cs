using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event Action OnHealthChangedEvent;

    [SerializeField]
    private float _maxHealth = 100f;
    
    [SerializeField]
    private bool _isPlayer = false;

    private float _health;

    public float Health
    {
        get => _health;
        private set
        {
            var newHealth = Mathf.Clamp(value, 0, _maxHealth);

            if (newHealth != _health)
            {
                _health = newHealth;
                HealthPercentage = Mathf.Lerp(0, _maxHealth, newHealth);
                
                if (_isPlayer)
                {
                    GameInstance.UiSystem.HealthBar.SetByPercent(newHealth/_maxHealth);

                    if (HealthPercentage == 0)
                    {
                        GameInstance.Instance.GameRestart();
                    }
                }
                OnHealthChangedEvent?.Invoke();
            }
        }
    }

    public float HealthPercentage { get; private set; }

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void DecreaseHealth(float damage)
    {
        Health -= damage;
    }
}
