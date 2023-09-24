using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurroundAudio : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if(other.TryGetComponent<FallingObject>(out FallingObject o))
            {
                o.canPlayLandingSound = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.TryGetComponent<FallingObject>(out FallingObject o))
            {
                o.canPlayLandingSound = false;
            }
        }
    }
}
