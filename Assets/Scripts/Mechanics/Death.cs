using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    [SerializeField] float _disappearDelay = 1f;
    Entity _entity;
    Movement _movement;
    Attack _attack;

    private Rigidbody2D _rb;

    private void Awake() {
        _entity = GetComponent<Entity>();
        _movement = GetComponent<Movement>();
        _attack = GetComponent<Attack>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        Health.OnDeath += ManageDeath;
    }

    private void OnDisable() {
        Health.OnDeath -= ManageDeath;
    }

    private void ManageDeath(Entity e) {
        if (_entity != e) return;

        _movement.PreventMove();
        _attack.PreventAttack();
        _rb.isKinematic = true;

        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine() {
        yield return new WaitForSeconds(_disappearDelay);

        Destroy(gameObject);
    }
}
