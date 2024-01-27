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
    private float _slowBulletsMultiplier;

    private ModifierSystem _modifierSystem;
    private float _movementSpeedMultiplier;

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
        if (modifier.ModifierTag == _fastMovementTag)
        {
            MovementSpeedMultiplier = _fastMovementMultiplier;
        }

        if (modifier.ModifierTag == _slowBulletsTag)
        {
            BulletSpeedMultiplier = _slowBulletsMultiplier;
        }
    }
}
