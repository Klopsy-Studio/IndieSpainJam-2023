using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSwallow : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter parent;
    [SerializeField] Collider swallowArea;

    bool canSwallow;

    [SerializeField] List<GravityBody> objectsAttracted = new List<GravityBody>();
    public void EndSwallow()
    {
        swallowArea.enabled = false;
        canSwallow = false;

        if(objectsAttracted.Count > 0)
        {
            foreach(GravityBody o in objectsAttracted)
            {
                o.attractor = GameManager.instance.planetAttractor;
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
                if(other.TryGetComponent<GravityBody>(out GravityBody newObject))
                {
                    if (!objectsAttracted.Contains(newObject))
                    {
                        objectsAttracted.Add(newObject);
                        newObject.attractor = parent._playerCharacterAttractor;
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
                if (collision.collider.TryGetComponent<GravityBody>(out GravityBody newObject))
                {
                    if (objectsAttracted.Contains(newObject))
                    {
                        objectsAttracted.Remove(newObject);
                        ObjectsValue value = newObject.GetComponent<ObjectsValue>();
                        parent._playerCharacterGrow.Grow(value.ReturnObjectValues().x);
                        GameManager.instance.UpdatePoints(value.ReturnObjectValues().y);
                        Destroy(newObject.gameObject);
                    }
                }
            }
        }
    }


}
