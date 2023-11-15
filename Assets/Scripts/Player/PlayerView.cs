using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerView : EntityView
{
    public enum PlayerState : int {
        Idle,
        Walking,
        Attacking,
        Jumping,
        Dead
    }

    protected override void OnStateExit()
    {
        switch ((PlayerState) _currentState)
        {
            case PlayerState.Idle: 
                break;

            case PlayerState.Walking:
                break;

            case PlayerState.Attacking:
                break;

            case PlayerState.Jumping:
                break;

            case PlayerState.Dead:
                break;
        }
    }

    protected override void OnStateUpdate()
    {
        base.OnStateUpdate();

        switch ((PlayerState)_currentState) {
            case PlayerState.Idle:
                break;

            case PlayerState.Walking:
                break;

            case PlayerState.Attacking:
                break;

            case PlayerState.Jumping:
                break;

            case PlayerState.Dead:
                break;
        }
    }

    protected override void OnStateEnter()
    {
        switch ((PlayerState)_currentState) {
            case PlayerState.Idle:
                break;

            case PlayerState.Walking:
                break;

            case PlayerState.Attacking:
                break;

            case PlayerState.Jumping:
                break;

            case PlayerState.Dead:
                break;
        }
    }

    protected override void RefreshProperties()
    {
        base.RefreshProperties();


    }
}
