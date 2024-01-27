using UnityEngine;

public class PawnTriggerActivator : AbstractPhysicTrigger<IPawn>
{
    [SerializeField]
    private AbstractActivable _activable;

    [SerializeField]
    private bool _deactivateOnExit;

    protected override void OnTriggerEntered(IPawn enteredObject)
    {
        _activable.Activate();
    }

    protected override void OnTriggerExited(IPawn exitedObject)
    {
        if (_deactivateOnExit)
        {
            _activable.Deactivate();
        }
    }
}
