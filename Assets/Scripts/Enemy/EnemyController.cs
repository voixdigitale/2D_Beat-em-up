using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : EntityController
{
    private EnemyAI _enemyAI;

    protected override void Awake()
    {
        base.Awake();
        _enemyAI = GetComponent<EnemyAI>();
    }

    protected override void GatherInput()
    {
        _frameInput = _enemyAI.FrameInput;
    }
}
