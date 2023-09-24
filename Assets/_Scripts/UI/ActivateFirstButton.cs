using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateFirstButton : MonoBehaviour
{
    [SerializeField] Button firstButton;
    [SerializeField] Sprite hoverSprite;

    private void OnEnable()
    {
        firstButton.image.sprite = hoverSprite;
    }
}
