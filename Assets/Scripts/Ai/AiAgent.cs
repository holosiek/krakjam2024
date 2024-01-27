using System;
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

    private readonly int _shootingHash = Animator.StringToHash("IsShooting");
    private readonly int _happyHash = Animator.StringToHash("IsHappy");

    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;
    private bool _hasSetDestination;
    private bool _isHoldingWeaponTrigger;
    private bool _isHappy;
    private Animator _animator;
    private MultipliersSystem _multipliersSystem;

    private NavMeshAgent NavMeshAgent => _navMeshAgent != null
        ? _navMeshAgent
        : _navMeshAgent = GetComponent<NavMeshAgent>();

    private MultipliersSystem MultipliersSystem => _multipliersSystem != null
        ? _multipliersSystem
        : _multipliersSystem = GameInstance.Instance.Get<MultipliersSystem>(); 

    private bool IsPlayerInAttackRange => _pawnAttackRangeDetector.IsPawnDetected;
    private bool IsPlayerVisible => _pawnVisibilityDetector.IsPawnDetected;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        MultipliersSystem.OnMovementSpeedMultiplierChange += OnMovementSpeedChange;
    }

    private void OnMovementSpeedChange(float multiplierValue)
    {
        NavMeshAgent.speed *= multiplierValue;
        NavMeshAgent.acceleration *= multiplierValue;
    }

    public void MakeMeHappy()
    {
        _isHappy = true;
        _animator.SetBool(_happyHash, true);
        NavMeshAgent.SetDestination(transform.position);
        TryDeactivateShooting();
    }

    private void Update()
    {
        if (_isHappy)
        {
            return;
        }

        if (IsPlayerInAttackRange)
        {
            AttackUpdate();
            return;
        }

        TryDeactivateShooting();

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
            _animator.SetBool(_shootingHash, true);
        }
    }

    private void TryDeactivateShooting()
    {
        if (_isHoldingWeaponTrigger)
        {
            _weapon.HandleInput(TriggerPhase.Released);
            _isHoldingWeaponTrigger = false;
            _animator.SetBool(_shootingHash, false);
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

    private void OnDestroy()
    {
        if (_multipliersSystem != null)
        {
            _multipliersSystem.OnMovementSpeedMultiplierChange -= OnMovementSpeedChange;
        }
    }
}
