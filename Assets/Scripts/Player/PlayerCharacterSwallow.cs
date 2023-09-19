using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSwallow : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter parent;
    [SerializeField] Collider swallowArea;

    bool canSwallow;

    [SerializeField] List<ObjectFall> objectsAttracted = new List<ObjectFall>();
    public void EndSwallow()
    {
        swallowArea.enabled = false;
        canSwallow = false;

        if(objectsAttracted.Count > 0)
        {
            foreach(ObjectFall o in objectsAttracted)
            {
                o.objectGravityBody.attractor = GameManager.instance.planetAttractor;
            }

            objectsAttracted.Clear();
        }
    }
    public void ActivateSwallow()
    {
        swallowArea.enabled = true;
        canSwallow = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (canSwallow)
        {
            if (other.CompareTag("Object"))
            {
                if(other.TryGetComponent<ObjectFall>(out ObjectFall newObject))
                {
                    if (!newObject.falling)
                    {
                        if (!objectsAttracted.Contains(newObject))
                        {
                            objectsAttracted.Add(newObject);
                            newObject.objectGravityBody.attractor = parent._playerCharacterAttractor;
                        }

                    }
                   
                }

            } 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canSwallow)
        {
            if (collision.collider.CompareTag("Object"))
            {
                if (collision.collider.TryGetComponent<ObjectFall>(out ObjectFall newObject))
                {
                    if (!newObject.falling)
                    {
                        if (objectsAttracted.Contains(newObject))
                        {
                            objectsAttracted.Remove(newObject);
                            Destroy(newObject.gameObject);
                        }
                    }
                }
            }
        }
    }


}
