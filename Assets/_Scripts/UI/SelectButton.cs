using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    private void OnEnable()
    {
        UIGameplay.instance.SelectFirstButton();
    }
}
