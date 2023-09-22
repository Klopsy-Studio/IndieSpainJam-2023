using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactZone : NegativeEffect
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        generalPoolManager.enableExplosionOnArrive = true;
        playerPoolManager.enableExplosionOnArrive = true;
    }
}
