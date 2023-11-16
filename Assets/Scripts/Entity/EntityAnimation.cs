using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public abstract class EntityAnimation : MonoBehaviour
{
    public bool IsMoving { get; set; }

    protected Entity _model;
    protected Animator _animator;
    protected Attack _attack;
    protected Movement _movement;

    protected virtual void Awake()
    {
        _model = GetComponent<Entity>();
        _animator = _model.GetAnimator();
        _attack = GetComponent<Attack>();
        _movement = GetComponent<Movement>();
    }

    protected virtual void OnEnable()
    {
        _attack.OnAttack += AttackAnimation;
    }
    
    protected virtual void OnDisable()
    {
        _attack.OnAttack -= AttackAnimation;
    }


    protected virtual void Update() {
        RefreshProperties();
        CorrectSpriteOrientation();
    }

    protected virtual void RefreshProperties()
    {
        _animator.SetBool("IsMoving", IsMoving);
    }

    protected virtual void AttackAnimation(Entity sender)
    {
        if (sender != _model) return;

        _animator.SetTrigger("Attack");
    }

    private void CorrectSpriteOrientation() {
        if (_movement.Orientation() < 0) {
            _animator.transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (_movement.Orientation() > 0) {
            _animator.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
