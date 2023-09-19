using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwallow : MonoBehaviour
{
    [SerializeField] Collider swallowArea;

    bool canSwallow;
    public void EndSwallow()
    {
        swallowArea.enabled = false;
        canSwallow = false;
    }
    public void ActivateSwallow()
    {
        swallowArea.enabled = true;
        canSwallow = true;
    }


    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canSwallow)
        {
            if (other.CompareTag("Object"))
            {
                other.GetComponent<GravityBody>().attractor = this.gameObject.GetComponent<GravityAttractor>();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canSwallow)
        {
            if (collision.collider.CompareTag("Object"))
            {
                Destroy(collision.gameObject);
            }
        }
    }


}
