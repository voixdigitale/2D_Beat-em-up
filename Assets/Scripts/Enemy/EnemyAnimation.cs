using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EntityAnimation
{

    private int IsDead = Animator.StringToHash("IsDead");
    protected override void OnEnable() {
        base.OnEnable();

        Health.OnDeath += Animate_Death;
    }

    protected override void OnDisable() {
        base.OnDisable();

        Health.OnDeath -= Animate_Death;
    }

    void Animate_Death(Entity e) {
        if (e != _entity) return;

        _animator.SetBool(IsDead, true);
    }
}
