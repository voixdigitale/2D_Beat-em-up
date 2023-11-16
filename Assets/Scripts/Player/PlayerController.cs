public class PlayerController : EntityController
{
    private PlayerInput _playerInput;

    protected new PlayerView _view {
        get => base._view as PlayerView;
        set => base._view = value;
    }

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
