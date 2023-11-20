using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Attack))]
[SelectionBase]

public abstract class Entity : MonoBehaviour, IHitable
{
    public Action<Entity> OnHit;

    [Header("Basic Settings")]
    [Tooltip("TeamID identifies who can interact and damage this Entity.\nDefault:\n -1: Neutral\n  0: Friendly\n  1: Enemy")]
    [SerializeField] protected int _teamID;

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

    public virtual void TakeHit(int teamId, Entity hitSource)
    {
        OnHit.Invoke(this);
    }

    public Animator GetAnimator() => _animator;
    public int Team() => _teamID;

    public int CurrentHealth() => _health.GetHP();
}
