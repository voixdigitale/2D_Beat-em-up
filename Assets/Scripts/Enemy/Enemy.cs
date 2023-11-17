using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public override void TakeHit(int teamId, GameObject hitSource)
    {
        Debug.Log("Enemy says : OUCH !");
    }
}
