using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public abstract class EntityAnimation : MonoBehaviour
{
    public bool IsMoving { get; set; }

    [SerializeField] private GameObject _hitVFX;

    protected Entity _entity;
    protected Animator _animator;
    protected Attack _attack;
    protected Movement _movement;

    protected virtual void Awake()
    {
        _entity = GetComponent<Entity>();
        _animator = _entity.GetAnimator();
        _attack = GetComponent<Attack>();
        _movement = GetComponent<Movement>();
    }

    protected virtual void OnEnable()
    {
        _attack.OnAttack += AttackAnimation;
        _entity.OnHit += HurtAnimation;
    }
    
    protected virtual void OnDisable()
    {
        _attack.OnAttack -= AttackAnimation;
        _entity.OnHit -= HurtAnimation;
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
        if (sender != _entity) return;

        _animator.SetTrigger("Attack");
    }

    protected virtual void HurtAnimation(Entity sender)
    {
        if (sender != _entity) return;

        _animator.SetTrigger("Hurt");
        Instantiate(_hitVFX, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
    }

    private void CorrectSpriteOrientation() {
        if (_movement.Orientation() < 0) {
            _animator.transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (_movement.Orientation() > 0) {
            _animator.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
