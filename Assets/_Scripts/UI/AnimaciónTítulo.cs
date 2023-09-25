using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimaciónTítulo : MonoBehaviour
{
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;
    public bool fadeOut;
    public ShakeRandomnessMode randomnessMode;
    void Start()
    {
        transform.DOShakeScale(duration, strength, vibrato, randomness, fadeOut, randomnessMode).SetEase(Ease.InOutBounce).SetLoops(-1,LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
