using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
    private PlayerInput _playerInput;

    protected override void Awake()
    {
        base.Awake();
        _playerInput = GetComponent<PlayerInput>();
    }

    /// <summary>
    /// Gets the FrameInput data from the PlayerInput class
    /// </summary>
    protected override void GatherInput()
    {
        _frameInput = _playerInput.FrameInput;
    }
}
