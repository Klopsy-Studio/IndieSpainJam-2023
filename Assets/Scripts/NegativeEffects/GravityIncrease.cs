using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIncrease : NegativeEffect
{


    [SerializeField] float gravityIncrease;

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        generalPoolManager.gravityIncrease = gravityIncrease;
        playerPoolManager.gravityIncrease = gravityIncrease;
    }
}
