using System;
using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour {
    public Action OnKnockbackStart;
    public Action OnKnockbackEnd;

    [SerializeField] private float _knockbackTime = .2f;

    private Movement _movement;
    private Entity _entity;

    private Vector3 _hitDirection;
    private float _knockbackThrust;

    private Rigidbody2D _rigidBody;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
        _movement = GetComponent<Movement>();
        _entity = GetComponent<Entity>();
    }

    private void OnEnable() {
        OnKnockbackStart += ApplyKnockbackForce;
        OnKnockbackEnd += StopKnockRoutine;
    }

    private void OnDisable() {
        OnKnockbackStart -= ApplyKnockbackForce;
        OnKnockbackEnd -= StopKnockRoutine;
    }

    public void GetKnockedBack(Vector2 hitDirection, float knockbackThrust) {
        _movement.PreventMove();
        _hitDirection = hitDirection;
        _knockbackThrust = knockbackThrust;

        OnKnockbackStart?.Invoke();
    }

    private void ApplyKnockbackForce() {
        _rigidBody.AddForce(_hitDirection * _knockbackThrust, ForceMode2D.Impulse);

        StartCoroutine(KnockRoutine());
    }

    private IEnumerator KnockRoutine() {
        yield return new WaitForSeconds(_knockbackTime);
        OnKnockbackEnd?.Invoke();
    }

    private void StopKnockRoutine() {
        _rigidBody.velocity = Vector2.zero;
        if (_entity.CurrentHealth() > 0) _movement.AllowMove();
    }
}