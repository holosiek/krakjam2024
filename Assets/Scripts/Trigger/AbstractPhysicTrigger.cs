using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class AbstractPhysicTrigger<TTriggerable> : MonoBehaviour
{
    [SerializeField]
    [ReadOnly]
    private int _objectsInTriggerCount = 0;

    protected readonly List<TTriggerable> _objectsInTrigger = new();

    private void OnTriggerEnter(Collider other)
    {
        List<TTriggerable> triggerables = new();
        other.gameObject.GetComponents(triggerables);

        foreach (TTriggerable enteredObject in triggerables)
        {
            TryAddObject(enteredObject);
        }
    }

    private void TryAddObject(TTriggerable enteredObject)
    {
        if (!_objectsInTrigger.Contains(enteredObject))
        {
            _objectsInTrigger.Add(enteredObject);
            _objectsInTriggerCount = _objectsInTrigger.Count;
            OnTriggerEntered(enteredObject);
        }
    }

    protected abstract void OnTriggerEntered(TTriggerable enteredObject);

    private void OnTriggerExit(Collider other)
    {
        List<TTriggerable> triggerables = new();
        other.gameObject.GetComponents(triggerables);

        foreach (TTriggerable exitedObject in triggerables)
        {
            TryRemoveObject(exitedObject);
        }
    }

    private void TryRemoveObject(TTriggerable exitedObject)
    {
        if (_objectsInTrigger.Remove(exitedObject))
        {
            _objectsInTriggerCount = _objectsInTrigger.Count;
            OnTriggerExited(exitedObject);
        }
    }

    protected abstract void OnTriggerExited(TTriggerable exitedObject);
}
