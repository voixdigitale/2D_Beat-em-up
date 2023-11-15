using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    protected FrameInput _frameInput;
    private Movement _movement;

    /// <summary>
    /// GatherInput NEEDS to be implemented to populate _frameInput!
    /// </summary>
    protected abstract void GatherInput();

    protected virtual void Awake()
    {
        _movement = GetComponent<Movement>();
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
