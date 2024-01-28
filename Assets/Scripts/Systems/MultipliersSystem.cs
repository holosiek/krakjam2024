using System;
using UnityEngine;

public class MultipliersSystem : GameSystem
{
    public Action<float> OnMovementSpeedMultiplierChange;

    [SerializeField]
    private ModifierTag _fastMovementTag;

    [SerializeField]
    private float _fastMovementMultiplier;

    [SerializeField]
    private ModifierTag _slowBulletsTag;

    [SerializeField]
    private float _slowBulletsMultiplier = 1.0f;

    private ModifierSystem _modifierSystem;
    private float _movementSpeedMultiplier = 1.0f;

    private bool _isSlowed = false;
    private bool _isMovementUpped = false;

    public float MovementSpeedMultiplier
    {
        get => _movementSpeedMultiplier;
        set
        {
            if (_movementSpeedMultiplier != value)
            {
                _movementSpeedMultiplier = value;
                OnMovementSpeedMultiplierChange?.Invoke(value);
            }
        }
    }
    public float BulletSpeedMultiplier { get; private set; } = 1.0f;

    private void Start()
    {
        _modifierSystem = GameInstance.Instance.Get<ModifierSystem>();
        _modifierSystem.OnModifierListUpdate += OnModifierListUpdate;
    }

    private void OnModifierListUpdate(Modifier modifier)
    {
        if (!_isMovementUpped && _modifierSystem.HasModifierTag(_fastMovementTag))
        {
            MovementSpeedMultiplier = _fastMovementMultiplier;
            _isMovementUpped = true;
        }
        if (_isMovementUpped && !_modifierSystem.HasModifierTag(_fastMovementTag))
        {
            MovementSpeedMultiplier = 1.0f;
            _isMovementUpped = false;
        }
		
        if (!_isSlowed && _modifierSystem.HasModifierTag(_slowBulletsTag))
        {
            BulletSpeedMultiplier = _slowBulletsMultiplier;
            _isSlowed = true;
        }
        if (_isSlowed && !_modifierSystem.HasModifierTag(_slowBulletsTag))
        {
            BulletSpeedMultiplier = 1.0f;
            _isSlowed = false;
        }
    }
}
