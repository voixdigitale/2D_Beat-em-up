using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity, IDamageable
{
    public override void TakeHit(int teamId, Entity hitSource)
    {
        base.TakeHit(teamId, hitSource);

        float relativePosition = new Vector2(transform.position.x - hitSource.transform.position.x, 0f).normalized.x;
        float knockbackThrust = hitSource.GetComponent<Attack>().GetKnockbackThrust();
        GetComponent<Knockback>().GetKnockedBack(new Vector2(relativePosition, 0f), knockbackThrust);

        GetComponent<Flash>().StartFlash();
    }

    public void TakeDamage(int teamId, int damageAmount) {
        _health.ReduceHealth(damageAmount);
    }

    public void SetTarget(Entity target) {
        GetComponent<EnemyAI>().SetTarget(target);
    }
}
