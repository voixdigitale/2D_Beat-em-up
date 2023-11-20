using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    
    private bool _canMove = true;
    private float _moveX = 0;
    private float _moveY = 0;

    private Rigidbody2D _rigidBody;


    private void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Move();
    }
    
    public void AllowMove()
    {
        _canMove = true;
    }
    public void PreventMove() {
        _rigidBody.velocity = Vector3.zero;
        _canMove = false;
    }

    private void Move()
    {
        if (!_canMove) return;

        Vector3 movement = new Vector2(_moveX * _moveSpeed, _moveY * _moveSpeed);
        _rigidBody.velocity = movement;
    }

    public void Start() {
        _canMove = true;
    }

    public void SetCurrentDirection(float currentXDirection, float currentYDirection) {
        if (!_canMove)
            return;

        _moveX = currentXDirection;
        _moveY = currentYDirection;
    }

    public void SetSpeed(float speed)
    {
        _moveSpeed = speed;
    }
    public bool IsMoving() => _rigidBody.velocity.magnitude > 0;
    public float Orientation() => _moveX;
}
