using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public override void TakeHit(int teamId, Entity hitSource)
    {
        base.TakeHit(teamId, hitSource);

        Debug.Log("Player says: OUCH!");
    }
}
