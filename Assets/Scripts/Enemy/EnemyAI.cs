using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public FrameInput FrameInput { get; private set; }

    [SerializeField] private Entity _target;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _timeBeforeAttack;
    [SerializeField] private int _minAttackTimes;
    [SerializeField] private int _maxAttackTimes;
    

    private Attack _attack;
    private bool _readyToAttack = false;
    private float _attackTime;
    private float _kickingAssDuration;

    void Awake()
    {
        _attack = GetComponent<Attack>();
    }

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
        return _attack.InRange() ? Vector2.zero : direction.normalized;
    }

    private bool EvaluateAttack()
    {
        if (!_attack.InRange()) return false;

        if (!_readyToAttack)
        {
            _readyToAttack = true;
            _attackTime = Time.time + _timeBeforeAttack;
            _kickingAssDuration = _attackTime + Random.Range(_minAttackTimes, _maxAttackTimes + 1) * 0.4f;
            return false;
        }
        else if (Time.time < _attackTime)
        {
            return false;
        }
        else if (Time.time < _kickingAssDuration) {
            return true;
        }
        else
        {
            _readyToAttack = false;
            return false;
        }
    }
}
