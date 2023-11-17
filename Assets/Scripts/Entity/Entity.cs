using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Attack))]
[SelectionBase]

public abstract class Entity : MonoBehaviour, IHitable
{
    [Header("Basic Settings")]
    [Tooltip("TeamID identifies who can interact and damage this Entity.\nDefault:\n -1: Neutral\n  0: Friendly\n  1: Enemy")]
    [SerializeField] protected int _teamID;
    [Tooltip("The maximum health points of this Entity.")]
    [SerializeField] protected int _healthPoints;
    [Tooltip("How fast this entity moves.")]
    [SerializeField] protected float _movementSpeed;

    [Header("Required Components")]
    [Tooltip("The animator component used to animate this Entity's sprites.")]
    [SerializeField] protected Animator _animator;

    protected Health _health;
    protected Movement _movement;

    protected virtual void Awake()
    {
        _health = GetComponent<Health>();
        _movement = GetComponent<Movement>();
    }

    /// <summary>
    /// Editor-only, it updates the values if a game designer changes the inspector during Play mode
    /// </summary>
    private void OnValidate()
    {
        if (_movement != null)
            _movement.SetSpeed(_movementSpeed);
    }
    public abstract void TakeHit(int teamId, GameObject hitSource);

    public Animator GetAnimator() => _animator;
    public int Team() => _teamID;
}
