using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public FrameInput FrameInput { get; private set; }

    private PlayerInputActions _playerInputActions;
    private InputAction _move;
    private InputAction _pause;

    private void Awake() {
        _playerInputActions = new PlayerInputActions();

        _move = _playerInputActions.Player.Move;
        _pause = _playerInputActions.Player.Pause;
    }

    private void OnEnable() {
        _playerInputActions.Enable();
    }

    private void OnDisable() {
        _playerInputActions.Disable();
    }

    private void Update() {
        FrameInput = GatherInput();
    }

    private FrameInput GatherInput() {
        return new FrameInput {
            Move = _move.ReadValue<Vector2>(),
            Pause = _pause.ReadValue<float>() > 0,
        };
    }
}

public struct FrameInput {
    public Vector2 Move;
    public bool Pause;
}