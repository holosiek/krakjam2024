using UnityEngine;

public class PawnTriggerActivator : AbstractPhysicTrigger<IPawnTrigger>
{
    [SerializeField]
    private AbstractActivable _activable;

    [SerializeField]
    private bool _deactivateOnExit;

    protected override void OnTriggerEntered(IPawnTrigger enteredObject)
    {
        _activable.Activate();
    }

    protected override void OnTriggerExited(IPawnTrigger exitedObject)
    {
        if (_deactivateOnExit)
        {
            _activable.Deactivate();
        }
    }
}
