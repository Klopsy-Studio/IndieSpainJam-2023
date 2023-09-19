using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour
{
    [SerializeField] Rigidbody objectRigid;
    [SerializeField] Collider objectCollider;
    public GravityBody objectGravityBody;
    public bool falling = true;


    private void OnCollisionEnter(Collision collision)
    {
        if (falling)
        {
            if (collision.collider.CompareTag("Player"))
            {
                Debug.Log("PlayerDamaged");
            }

            if (collision.collider.CompareTag("Planet"))
            {
                falling = false;
            }
        }
    }
}
