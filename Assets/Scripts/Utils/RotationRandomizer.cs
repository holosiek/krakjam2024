using UnityEngine;

public class RotationRandomizer : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotationAxis;

    [SerializeField]
    private Vector2 _range;

    private void Awake()
    {
        var xOffset = Random.Range(_range.x, _range.y);
        var yOffset = Random.Range(_range.x, _range.y); 
        var zOffset = Random.Range(_range.x, _range.y);

        var offsetVector = new Vector3(_rotationAxis.x * xOffset, _rotationAxis.y * yOffset, _rotationAxis.z * zOffset);
        transform.localEulerAngles += offsetVector;
    }
}
