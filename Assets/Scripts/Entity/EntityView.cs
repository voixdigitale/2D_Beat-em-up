using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public abstract class EntityView : MonoBehaviour
{
    public bool IsMoving { get; set; }

    protected int _currentState;
    protected Entity _model;
    protected Animator _animator;

    protected virtual void Awake()
    {
        _model = GetComponent<Entity>();
        _animator = _model.GetAnimator();
    }
    protected virtual void Start() {
        TransitionToState(0);
    }

    private void Update() {
        OnStateUpdate();
    }

    private void TransitionToState<T>(T state) where T : struct, System.IConvertible {
        OnStateExit();
        _currentState = System.Convert.ToInt32(state);
        OnStateEnter();
    }

    protected abstract void OnStateExit();

    protected virtual void OnStateUpdate()
    {
        RefreshProperties();
    }

    protected abstract void OnStateEnter();

    protected virtual void RefreshProperties()
    {
        _animator.SetBool("IsMoving", IsMoving);
    }


    public T GetState<T>() where T : struct, System.IConvertible {
        System.Object state = _currentState;
        return (T)state;
    }
}
