using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRateIncrease : NegativeEffect
{
    [SerializeField] PoolManagerIncrease generalPoolIncrease;
    [SerializeField] PoolManagerIncrease playerPoolIncrease;
    public override void ApplyEffect()
    {
        base.ApplyEffect();

        generalPoolIncrease.poolToIncrease = generalPoolManager;
        playerPoolIncrease.poolToIncrease = playerPoolManager;

        generalPoolIncrease.IncreasePoolManagerRate();
        playerPoolIncrease.IncreasePoolManagerRate();
    }

}


[System.Serializable]
public class PoolManagerIncrease
{
    [HideInInspector] public PoolManager poolToIncrease;
    [SerializeField] float maxRateIncrease;
    [SerializeField] float minRateIncrease;

    public void IncreasePoolManagerRate()
    {
        poolToIncrease.maxSpawnRatio += maxRateIncrease;
        poolToIncrease.minSpawnRation += minRateIncrease;
    }

}
