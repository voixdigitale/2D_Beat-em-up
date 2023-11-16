using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Attack : MonoBehaviour
{
    public static Action<Entity> OnAttack;

    private Entity _entity;

    private bool _canAttack = true;
    private bool _isAttacking = false;
    private float _comboResetTimer;
    private float _comboResetTime;
    private float _attackAnimationTime;
    private float _lastAttackTime;
    private float _maxCombo;
    private int _comboCounter;

    private void Awake() {
        _entity = GetComponent<Entity>();
    }

    private void OnEnable() {
        OnAttack += ResetCombo;
    }

    private void OnDisable() {
        OnAttack -= ResetCombo;
    }


    private void Update() {
        PerformAttack();
    }

    private void AllowAttack() {
        _canAttack = true;
    }
    private void PreventAttack() {
        _canAttack = false;
    }

    private void PerformAttack() {
        if (!_canAttack) { return; }

        if (_isAttacking && Time.time >= _lastAttackTime) {
            _isAttacking = false;
            OnAttack?.Invoke(_entity);
        }

        _comboResetTimer = Time.time + _comboResetTime;
        _lastAttackTime = Time.time + _attackAnimationTime;
    }

    private void ResetCombo(Entity sender) {
        if (_entity != sender) return;

        if (Time.time >= _comboResetTimer) {
            _comboCounter = 0;
        }
    }

    public void SetAttacking(bool isAttacking) {
        _isAttacking = isAttacking;
    }

    public bool IsAttacking() => _isAttacking;
}
