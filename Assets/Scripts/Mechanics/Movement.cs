using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private bool _canMove = true;
    private float _speed;
    private float _moveX = 0;
    private float _moveY = 0;

    private Rigidbody2D _rigidBody;


    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Move();
    }
    
    private void AllowMove() {
        _canMove = true;
    }
    private void PreventMove() {
        _canMove = false;
    }

    private void Move()
    {
        if (!_canMove)
        {
            return;
        }

        Vector3 movement = new Vector2(_moveX * _speed, _moveY * _speed);
        _rigidBody.velocity = movement;
    }

    public void Init(float speed, bool canMove) {
        _speed = speed;
        _canMove = canMove;
    }

    public void SetCurrentDirection(float currentXDirection, float currentYDirection) {
        _moveX = currentXDirection;
        _moveY = currentYDirection;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    public bool IsMoving() => new Vector2(_moveX, _moveY).magnitude > 0;
}
