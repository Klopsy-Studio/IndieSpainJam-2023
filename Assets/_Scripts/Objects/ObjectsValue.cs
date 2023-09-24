using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class ObjectsValue : MonoBehaviour
{
   
    public float growthValue;
    public float kgPoints;


    //x for character growth, y for kgpoints
    public Vector2 ReturnObjectValues()
    {
        return new Vector2(growthValue, kgPoints);
    }
}
