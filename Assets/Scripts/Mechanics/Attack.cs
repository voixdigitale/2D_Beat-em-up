using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Attack : MonoBehaviour
{
    public Action<Entity> OnAttack;

    [SerializeField] private float _attackCooldown;
    [SerializeField] private Collider2D _attackRangeCollider;

    private Entity _entity;
    private Movement _movement;

    private bool _canAttack = true;
    private bool _isAttacking = false;
    private float _lastAttackTime;
    private bool _inAttackRange;

    private void Awake() {
        _entity = GetComponent<Entity>();
        _movement = GetComponent<Movement>();
    }
    
    private void Update() {
        AttemptAttack();
    }

    private void AllowAttack() {
        _canAttack = true;
    }
    private void PreventAttack() {
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
        _inAttackRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        _inAttackRange = false;
    }

    public bool InRange() => _inAttackRange;
}
