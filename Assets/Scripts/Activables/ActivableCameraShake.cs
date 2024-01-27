using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class ActivableCameraShake : AbstractActivable
{
    [SerializeField]
    private Vector3 _impulseVelocity;

    private CinemachineImpulseSource _impulseSource;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public override void Activate()
    {
        _impulseSource.GenerateImpulse(_impulseVelocity);
    }

    public override void Deactivate()
    {

    }
}
