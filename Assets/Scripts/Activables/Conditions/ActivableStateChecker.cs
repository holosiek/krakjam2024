using System;
using System.Collections.Generic;
using UnityEngine;

public class ActivableStateChecker : MonoBehaviour
{
    [SerializeField]
    private List<AbstractActivable> _activeActivables;

    [SerializeField]
    private List<AbstractActivable> _deactivatedActivables;

    [SerializeField]
    private AbstractActivable _triggerActivable;

    private bool _hasTriggered;

    private void Update()
    {
        if (!_hasTriggered)
        {
            CheckActivables();
        }
    }

    private void CheckActivables()
    {
        foreach (var activable in _activeActivables)
        {
            if (!activable.IsActive)
            {
                return;
            }
        }

        foreach (var activable in _deactivatedActivables)
        {
            if (activable.IsActive)
            {
                return;
            }
        }

        _triggerActivable?.Activate();
        _hasTriggered = true;
        gameObject.SetActive(false);
    }
}
