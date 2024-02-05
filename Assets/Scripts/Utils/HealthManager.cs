using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public event Action OnHealthChangedEvent;

	[SerializeField]
	private float _maxHealth = 100f;

	private float _health;

	public float Health
	{
		get => _health;
		set
		{
			var newHealth = Mathf.Clamp(value, 0, _maxHealth);

			if (newHealth != _health)
			{
				_health = newHealth;
				HealthPercentage = Mathf.Lerp(0, _maxHealth, newHealth);
				OnHealthChangedEvent?.Invoke();
			}
		}
	}

	public float HealthPercentage { get; private set; }
	public float MaxHealth => _maxHealth;

	private void Awake()
	{
		_health = _maxHealth;
	}

	public void AddHealth(float additionalHealth)
	{
		Health += additionalHealth;
	}

	public void DecreaseHealth(float damage)
	{
		Health -= damage;
	}
}
