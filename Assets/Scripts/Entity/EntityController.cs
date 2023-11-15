using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    protected FrameInput _frameInput;
    protected Entity _model;
    protected Movement _movement;

    protected EntityView _view;

    /// <summary>
    /// GatherInput NEEDS to be implemented to populate _frameInput!
    /// </summary>
    protected abstract void GatherInput();

    protected virtual void Awake()
    {
        _movement = GetComponent<Movement>();
        _model = GetComponent<Entity>();

        _view = _model.View;
    }

    protected virtual void Update()
    {
        GatherInput();
        Movement();
    }

    protected virtual void Movement()
    {
        _movement.SetCurrentDirection(_frameInput.Move.x, _frameInput.Move.y);
    }
}
