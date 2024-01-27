using System;
using UnityEngine;

public class OnHealthChangedActivator : MonoBehaviour
{
    [SerializeField]
    private HealthManager _healthManager;

    [SerializeField]
    private AbstractActivable _activable;

    [SerializeField]
    private bool _activateOnHealthTreshold;

    [SerializeField]
    [Range(0f, 1f)]
    private float _healthTreshold;

    private void Start()
    {
        _healthManager.OnHealthChangedEvent += OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        if (!_activateOnHealthTreshold || _healthManager.HealthPercentage <= _healthTreshold)
        {
            _activable.Activate();
        }
    }

    private void OnDestroy()
    {
        if (_healthManager != null)
        {
            _healthManager.OnHealthChangedEvent -= OnHealthChanged;
        }
    }
}
