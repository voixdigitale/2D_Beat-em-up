using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Action<Entity> OnAttack;
    public Action<Entity> OnAttackAnimation;

    [SerializeField] private float _attackCooldown;
    [SerializeField] private int _damagePoints;
    [SerializeField] private float _knockbackThrust = 2f;
    [SerializeField] private Collider2D _attackRangeCollider;

    private Entity _entity;
    private Movement _movement;

    private bool _canAttack = true;
    private bool _isAttacking = false;
    private float _lastAttackTime;
    private bool _inAttackRange;
    private List<Entity> _targetsInRange = new List<Entity>();

    private void Awake() {
        _entity = GetComponent<Entity>();
        _movement = GetComponent<Movement>();
    }

    void OnEnable()
    {
        OnAttackAnimation += CheckForHit;
        Health.OnDeath += RefreshTargetList;
    }

    void OnDisable() {
        OnAttackAnimation -= CheckForHit;
        Health.OnDeath -= RefreshTargetList;
    }

    private void Update() {
        AttemptAttack();
    }

    public void AllowAttack() {
        _canAttack = true;
    }
    public void PreventAttack() {
        _canAttack = false;
    }

    private void AttemptAttack() {
        if (!_canAttack) { return; }

        if (_isAttacking && Time.time >= _lastAttackTime)
        {
            _isAttacking = false;
            OnAttack?.Invoke(_entity);
            _lastAttackTime = Time.time + _attackCooldown;
        }
    }

    public void SetAttacking(bool isAttacking) {
        _isAttacking = isAttacking;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponentInParent<Entity>() == null) { return; }

        _inAttackRange = true;
        
        Entity entityInRange = other.gameObject.GetComponentInParent<Entity>();
        if (entityInRange.Team() != _entity.Team() && entityInRange.CurrentHealth() > 0)
        {
            _targetsInRange.Add(entityInRange);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _inAttackRange = false;

        Entity entityInRange = other.gameObject.GetComponentInParent<Entity>();
        if (entityInRange?.Team() != _entity.Team() && _targetsInRange.Contains(entityInRange))
        {
            _targetsInRange.Remove(entityInRange);
        }
    }

    private void CheckForHit(Entity sender)
    {
        foreach (Entity e in _targetsInRange.ToList())
        {
            float relativePosition = new Vector2(e.transform.position.x - transform.position.x, 0f).normalized.x;
            float orientation = _entity.GetAnimator().transform.localScale.x;
            if (relativePosition == orientation)
            {
                IHitable iHitable = e.GetComponent<IHitable>();
                iHitable?.TakeHit(e.Team(), sender);

                IDamageable iDamageable = e.GetComponent<IDamageable>();
                iDamageable?.TakeDamage(e.Team(), _damagePoints);
                
            }
        }
    }

    private void RefreshTargetList(Entity e) {
        if(_targetsInRange.Contains(e)) _targetsInRange.Remove(e);
    }

    public bool InRange() => _inAttackRange;
    public float GetKnockbackThrust() => _knockbackThrust;
}
