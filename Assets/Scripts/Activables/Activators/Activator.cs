using System.Collections.Generic;
using UnityEngine;

public class Activator : AbstractActivable
{
    [SerializeField]
    private List<AbstractActivable> _activablesToActivate;

    [SerializeField]
    private List<AbstractActivable> _activablesToDeactivate;

    public override void Activate()
    {
        foreach (var activable in _activablesToActivate)
        {
            activable.Activate();
        }

        foreach (var activable in _activablesToDeactivate)
        {
            activable.Deactivate();
        }
    }

    public override void Deactivate()
    {
        foreach (var activable in _activablesToActivate)
        {
            activable.Deactivate();
        }

        foreach (var activable in _activablesToDeactivate)
        {
            activable.Activate();
        }
    }
}
