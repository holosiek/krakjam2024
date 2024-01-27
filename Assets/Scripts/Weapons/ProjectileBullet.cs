using System.Collections;
using UnityEngine;

public class ProjectileBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _lifetime;

    public void Fire(Vector3 direction)
    {
        StartCoroutine(FireRoutine(direction));
    }

    private IEnumerator FireRoutine(Vector3 direction)
    {
        var currentTime = 0f;
        direction = transform.InverseTransformDirection(direction);

        while (_lifetime > currentTime)
        {
            var deltaTime = Time.deltaTime;
            currentTime += deltaTime;
            transform.Translate(direction * _speed * deltaTime);
            yield return null;
        }

        Destroy(this);
    }
}
