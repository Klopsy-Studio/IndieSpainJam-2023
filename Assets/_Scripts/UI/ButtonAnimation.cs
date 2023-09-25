using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonAnimation : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler
{
    private Image image;

    [SerializeField] private Sprite regularSprite;
    [SerializeField] private Sprite selectedSprite;

    private Tween selectTween;


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        AudioManager.instance.Play("Hover");
        Debug.Log("Seleccionado");
        image.sprite = selectedSprite;
        transform.localScale = Vector3.one;
        selectTween = transform.DOShakeScale(0.15f, 0.6f, 25, 90, true, ShakeRandomnessMode.Full).SetUpdate(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        image.sprite = regularSprite;
        transform.localScale = Vector3.one;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        AudioManager.instance.Play("Click");
        transform.localScale = Vector3.one;
        selectTween.Kill();
        transform.DOPunchScale(new Vector3(-0.1f, -0.1f, -0.1f), 0.2f).OnComplete(() => { transform.localScale = Vector3.one; }).SetUpdate(true);
        image.sprite = regularSprite;
    }
}
