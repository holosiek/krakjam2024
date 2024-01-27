using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AiAgent : MonoBehaviour
{
    [SerializeField]
    private PawnDetector _pawnVisibilityDetector;

    [SerializeField]
    private PawnDetector _pawnAttackRangeDetector;

    [SerializeField]
    private ShootingWeapon _weapon;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private float _patrolRange;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;
    private bool _hasSetDestination;
    private bool _isHoldingWeaponTrigger;

    private NavMeshAgent NavMeshAgent => _navMeshAgent != null
        ? _navMeshAgent
        : _navMeshAgent = GetComponent<NavMeshAgent>();

    private bool IsPlayerInAttackRange => _pawnAttackRangeDetector.IsPawnDetected;
    private bool IsPlayerVisible => _pawnVisibilityDetector.IsPawnDetected;

    private void Update()
    {
        if (IsPlayerInAttackRange)
        {
            AttackUpdate();
            return;
        }

        if (_isHoldingWeaponTrigger)
        {
            _weapon.HandleInput(TriggerPhase.Released);
            _isHoldingWeaponTrigger = false;
        }

        if (IsPlayerVisible)
        {
            ChaseUpdate();
            _weapon.HandleInput(TriggerPhase.Released);
        }
        else
        {
            PatrolUpdate();
        }
    }

    private void AttackUpdate()
    {
        NavMeshAgent.SetDestination(transform.position);

        var pawnPosition = _pawnAttackRangeDetector.TriggeredPawn.PawnRoot.position;
        pawnPosition.y = transform.position.y;
        transform.LookAt(pawnPosition);

        if (!_isHoldingWeaponTrigger)
        {
            _weapon.HandleInput(TriggerPhase.Started);
            _isHoldingWeaponTrigger = true;
        }
    }

    private void ChaseUpdate()
    {
        NavMeshAgent.SetDestination(_pawnVisibilityDetector.TriggeredPawn.PawnRoot.position);
    }

    private void PatrolUpdate()
    {
        if (!_hasSetDestination)
        {
            CalculateNewDestination();
        }

        if (_hasSetDestination)
        {
            NavMeshAgent.SetDestination(_destination);
        }

        Vector3 distanceToWalkPoint = transform.position - _destination;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            _hasSetDestination = false;
        }
    }

    private void CalculateNewDestination()
    {
        float randomZ = UnityEngine.Random.Range(-_patrolRange, _patrolRange);
        float randomX = UnityEngine.Random.Range(-_patrolRange, _patrolRange);

        _destination = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_destination, -transform.up, 2f, _groundLayer))
        {
            _hasSetDestination = true;
        }
    }
}
