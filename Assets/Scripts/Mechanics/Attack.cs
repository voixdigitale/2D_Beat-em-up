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

    private Entity _entity;

    private bool _canAttack = true;
    private bool _isAttacking = false;
    private float _lastAttackTime;

    private void Awake() {
        _entity = GetComponent<Entity>();
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
}
