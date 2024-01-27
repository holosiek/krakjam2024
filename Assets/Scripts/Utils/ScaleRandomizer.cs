using UnityEngine;

public class ScaleRandomizer : MonoBehaviour
{
    [SerializeField]
    private Vector3 _scaleAxis;

    [SerializeField]
    private Vector2 _range;

    private void Awake()
    {
        var xOffset = Random.Range(_range.x, _range.y);
        var yOffset = Random.Range(_range.x, _range.y);
        var zOffset = Random.Range(_range.x, _range.y);

        var offsetVector = new Vector3(_scaleAxis.x * xOffset, _scaleAxis.y * yOffset, _scaleAxis.z * zOffset);
        transform.localScale += offsetVector;
    }
}
