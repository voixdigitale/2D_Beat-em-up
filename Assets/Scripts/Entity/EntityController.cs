using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    protected FrameInput _frameInput;
    protected Entity _model;
    protected Movement _movement;
    protected Attack _attack;

    protected EntityAnimation Animation;

    /// <summary>
    /// GatherInput NEEDS to be implemented to populate _frameInput!
    /// </summary>
    protected abstract void GatherInput();

    protected virtual void Awake()
    {
        _movement = GetComponent<Movement>();
        _attack = GetComponent<Attack>();
        _model = GetComponent<Entity>();

        Animation = _model.Animation;
    }

    protected virtual void Update()
    {
        GatherInput();
        Movement();
        Attack();
        UpdateValues();
    }

    protected virtual void Movement()
    {
        _movement.SetCurrentDirection(_frameInput.Move.x, _frameInput.Move.y);
    }

    protected virtual void Attack() {
        _attack.SetAttacking(_frameInput.Attack);
    }

    protected virtual void UpdateValues() {
        Animation.IsMoving = _movement.IsMoving();
        Animation.IsAttacking = _attack.IsAttacking();
    }
}
