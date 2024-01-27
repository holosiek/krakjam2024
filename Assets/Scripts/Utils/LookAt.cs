using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    private Transform _observedTransform;

    private void Update()
    {
        transform.LookAt(_observedTransform);
    }
}
