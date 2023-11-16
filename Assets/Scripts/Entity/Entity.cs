using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Attack))]
[SelectionBase]

public class Entity : MonoBehaviour
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

    [field: Header("MVC Setup")]
    [Tooltip("Drag here the code that will manage the visuals of this Entity.")]
    [field: SerializeField]
    public EntityView View { get; private set; }
    [Tooltip("Drag here the code that will act as the controller for this Entity.")]
    [field: SerializeField]
    public EntityController Controller { get; private set; }

    protected Health _health;
    protected Movement _movement;

    protected virtual void Awake()
    {
        _health = GetComponent<Health>();
        _movement = GetComponent<Movement>();

        _health.Init(_healthPoints);
        _movement.Init(_movementSpeed, true);
    }

    /// <summary>
    /// Editor-only, it updates the values if a game designer changes the inspector during Play mode
    /// </summary>
    private void OnValidate()
    {
        if (_movement != null)
            _movement.SetSpeed(_movementSpeed);
    }

    public Animator GetAnimator() => _animator;
}
