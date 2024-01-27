using UnityEngine;

public class PawnTrigger : MonoBehaviour, IPawn
{
    [SerializeField]
    private Transform _pawnRoot;
    public Transform PawnRoot => _pawnRoot;
}