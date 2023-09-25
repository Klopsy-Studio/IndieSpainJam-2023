using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreUpgrade : MonoBehaviour
{
    public UpgradeData data;
    public TextMeshProUGUI descriptionText;
    public Image _image;
    public TextMeshProUGUI priceText;

    public void FillData()
    {
        descriptionText.text = data.descriptionString;
        _image.sprite = data.iconSprite;
        priceText.text = data.price.ToString();
    }
}
