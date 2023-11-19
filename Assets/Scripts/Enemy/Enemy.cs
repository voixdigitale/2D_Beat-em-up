using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public override void TakeHit(int teamId, GameObject hitSource)
    {
        base.TakeHit(teamId, hitSource);

        float relativePosition = new Vector2(transform.position.x - hitSource.transform.position.x, 0f).normalized.x;
        float knockbackThrust = hitSource.GetComponent<Attack>().GetKnockbackThrust();
        GetComponent<Knockback>().GetKnockedBack(new Vector2(relativePosition, 0f), knockbackThrust);

        GetComponent<Flash>().StartFlash();
    }
}
