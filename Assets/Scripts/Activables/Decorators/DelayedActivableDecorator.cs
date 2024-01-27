using System.Collections;
using UnityEngine;

public class DelayedActivableDecorator : AbstractActivable
{
    [SerializeField]
    private AbstractActivable _decoratedActivable;

    [SerializeField]
    private float _activationDelay = 0f;

    [SerializeField]
    private float _deactivationDelay = 0f;

    public override void Activate()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        yield return new WaitForSeconds(_activationDelay);

        _decoratedActivable?.Activate();
    }

    public override void Deactivate()
    {
        StartCoroutine(DeactivationRoutine());
    }

    private IEnumerator DeactivationRoutine()
    {
        yield return new WaitForSeconds(_deactivationDelay);

        _decoratedActivable?.Deactivate();
    }
}
