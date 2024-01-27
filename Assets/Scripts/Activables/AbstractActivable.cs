using UnityEngine;

public abstract class AbstractActivable : MonoBehaviour
{
    public virtual bool IsActive { get; protected set; } = false;

    public abstract void Activate();
    public abstract void Deactivate();
}
