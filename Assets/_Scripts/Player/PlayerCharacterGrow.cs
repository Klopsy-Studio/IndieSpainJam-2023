using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterGrow : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter parent;

    public float growthReduction = 0;
    public void Grow(float growth)
    {
        growth -= growthReduction;

        if (growth <= 0) { growth = 0; }

        parent.transform.localScale = new Vector3(transform.localScale.x + growth, transform.localScale.y + growth, transform.localScale.z + growth);
    }

}
