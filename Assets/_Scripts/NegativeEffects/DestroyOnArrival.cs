using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnArrival : NegativeEffect
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        generalPoolManager.enableDestructionOnArrive = true;
        playerPoolManager.enableDestructionOnArrive = true;
    }
}
