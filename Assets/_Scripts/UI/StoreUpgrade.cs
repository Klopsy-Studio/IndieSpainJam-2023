using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreUpgrade : ScriptableObject
{
    public string descriptionString;
    public Sprite iconSprite;
    public float price;
    public TextMeshProUGUI descriptionText;
    public Image _image;
    public TextMeshProUGUI priceText;

    public void FillData()
    {
        descriptionText.text = descriptionString;
        _image.sprite = iconSprite;
        priceText.text = price.ToString();
    }
}
