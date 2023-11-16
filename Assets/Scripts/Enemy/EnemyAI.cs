using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public FrameInput FrameInput { get; private set; }

    [SerializeField] private Entity _target;
    [SerializeField] private float _rangeRadius;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Collider2D _attackRangeCollider;

    private bool _inAttackRange;


    void Update()
    {
        FrameInput = GatherInput();
    }

    private FrameInput GatherInput() {
        return new FrameInput {
            Move = EvaluateDirection(),
            Attack = EvaluateAttack(),
        };
    }

    private Vector2 EvaluateDirection()
    {
        Vector2 direction = _target.transform.position - transform.position;
        return _inAttackRange ? Vector2.zero : direction.normalized;
    }

    private bool EvaluateAttack()
    {
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _inAttackRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        _inAttackRange = false;
    }
}
