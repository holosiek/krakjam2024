using System.Collections;
using UnityEngine;

public class ActivableSaturation : AbstractActivable
{
    [SerializeField]
    private float _desaturationTime = 3f;

    private bool _isDesaturating;
    private FullScreenEffectSystem _fullScreenEffectSystem;

    private FullScreenEffectSystem FullScreenEffectSystem => _fullScreenEffectSystem != null
        ? _fullScreenEffectSystem
        : _fullScreenEffectSystem = GameInstance.Instance.Get<FullScreenEffectSystem>();

    public override void Activate()
    {
        if (!IsActive)
        {
            FullScreenEffectSystem.Saturation = 1;
            IsActive = true;
        }
    }

    public override void Deactivate()
    {
        if (IsActive && !_isDesaturating)
        {
            StartCoroutine(DeactivationRoutine());
        }
    }

    private IEnumerator DeactivationRoutine()
    {
        _isDesaturating = true;
        var currentTime = 0f;

        while (currentTime < _desaturationTime)
        {
            FullScreenEffectSystem.Saturation = 1 - (currentTime / _desaturationTime);
            currentTime += Time.deltaTime;
            yield return null;
        }

        FullScreenEffectSystem.Saturation = 0;
        _isDesaturating = false;
        IsActive = false;
    }
}
