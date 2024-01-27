using UnityEngine;

public class PositionLerper : MonoBehaviour
{
    [SerializeField]
    private Transform _lowPosition;

    [SerializeField]
    private Transform _highPostion;

    [SerializeField]
    private float _lerpTime;

    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime < _lerpTime)
        {
            var position = Vector3.Lerp(_lowPosition.position, _highPostion.position, _currentTime / _lerpTime);
            transform.position = position;
        }
    }
}
