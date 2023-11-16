using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public abstract class EntityAnimation : MonoBehaviour
{
    public bool IsMoving { get; set; }
    public bool IsAttacking { get; set; }

    protected Entity _model;
    protected Animator _animator;

    protected virtual void Awake()
    {
        _model = GetComponent<Entity>();
        _animator = _model.GetAnimator();
    }


    protected virtual void Update() {
        RefreshProperties();
    }

    protected virtual void RefreshProperties()
    {
        _animator.SetBool("IsMoving", IsMoving);
        _animator.SetBool("IsAttacking", IsAttacking);
    }
}
