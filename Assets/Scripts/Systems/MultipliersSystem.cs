using System;
using UnityEngine;

public class MultipliersSystem : GameSystem
{
    [SerializeField]
    private ModifierTag _fastMovementTag;

    [SerializeField]
    private float _fastMovementMultiplier;

    [SerializeField]
    private ModifierTag _slowBulletsTag;

    [SerializeField]
    private float _slowBulletsMultiplier;

    private ModifierSystem _modifierSystem;

    public float MovementSpeedMultiplier { get; private set; } = 1.0f;
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
