using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NegativeEffectManager : MonoBehaviour
{
    [SerializeField] List<NegativeEffect> effects = new List<NegativeEffect>();
    public PoolManager generalPoolManager;
    public PoolManager playerPoolManager;

    [SerializeField] Animator negativeEffectsAnimation;
    [SerializeField] TextMeshProUGUI negativeEffectBox;
    public void ApplyAndRemoveRandomEffect()
    {
        if(effects.Count> 0)
        {
            int chosenEffect = Random.Range(0, effects.Count);
            effects[chosenEffect].ApplyEffect();
            negativeEffectBox.SetText(effects[chosenEffect].negativeEffectName);
            negativeEffectsAnimation.SetTrigger("appear");
            effects.RemoveAt(chosenEffect);

        }
        else
        {
            
            Debug.Log("No negative effects lef!");          
        }
    }
}
