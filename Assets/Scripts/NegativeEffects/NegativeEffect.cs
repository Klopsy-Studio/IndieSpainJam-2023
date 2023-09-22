using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeEffect : MonoBehaviour
{
    [HideInInspector] public NegativeEffectManager manager;
    [HideInInspector] public PoolManager generalPoolManager;
    [HideInInspector] public PoolManager playerPoolManager;

    public string negativeEffectName;

    private void Start()
    {
        manager = GetComponent<NegativeEffectManager>();
        generalPoolManager = manager.generalPoolManager;
        playerPoolManager = manager.playerPoolManager;
    }

    public virtual void ApplyEffect()
    {
        Debug.Log(negativeEffectName + " applied");
    }
}
