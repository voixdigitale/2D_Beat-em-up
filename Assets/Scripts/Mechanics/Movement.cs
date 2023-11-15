using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private bool _canMove = true;
    private float _moveX;
    private float _moveY;

    private Rigidbody2D _rigidBody;


    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        Move();
    }

    public void SetCurrentDirection(float currentXDirection, float currentYDirection) {
        _moveX = currentXDirection;
        _moveY = currentYDirection;
    }

    private void AllowMove() {
        _canMove = true;
    }
    private void PreventMove() {
        _canMove = false;
    }

    private void Move() {
        if (!_canMove) { return; }

        Vector3 movement = new Vector2(_moveX * _speed, _moveY * _speed);
        _rigidBody.velocity = movement;
    }
}
