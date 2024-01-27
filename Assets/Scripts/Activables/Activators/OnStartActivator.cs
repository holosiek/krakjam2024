using UnityEngine;

public class OnStartActivator : MonoBehaviour
{
    [SerializeField]
    private AbstractActivable _activable;

    private void Start()
    {
        _activable?.Activate();
    }
}
