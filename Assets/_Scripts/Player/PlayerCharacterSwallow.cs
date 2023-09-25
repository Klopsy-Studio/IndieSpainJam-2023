using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSwallow : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter parent;
    [SerializeField] Collider swallowArea;

    [HideInInspector] public bool canSwallow;

    [SerializeField] public List<GravityBody> objectsAttracted = new List<GravityBody>();

    [SerializeField] Animator swallowVfx;
    public void EndSwallow()
    {
        swallowArea.enabled = false;
        canSwallow = false;
        parent._playerCharacterAnimations.SetAnimState("swallow", false);

        if (objectsAttracted.Count > 0)
        {
            foreach(GravityBody o in objectsAttracted)
            {
                o.attractor = GameManager.instance.planetAttractor;
                o.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            objectsAttracted.Clear();
        }
    }



    public void ActivateSwallowVFX()
    {
        swallowVfx.SetBool("appear", true);
    }

    public void DeactivateSwallowVfx()
    {
        swallowVfx.SetBool("appear", false);
    }
    public void ActivateSwallow()
    {
        swallowArea.enabled = true;
        parent._playerCharacterAnimations.SetAnimState("swallow", true);
        canSwallow = true;
    }

    public void PlaySwallowSFX()
    {
        AudioManager.instance.Play("Swallow");
    }

    public void StopSwallowSFX()
    {
        AudioManager.instance.Stop("Swallow");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canSwallow)
        {
            if (other.CompareTag("Object"))
            {
                if (other.TryGetComponent<GravityBody>(out GravityBody newObject))
                {
                    newObject.attractor = GameManager.instance.planetAttractor;
                    newObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canSwallow)
        {
            if (other.CompareTag("Object"))
            {
                if (other.TryGetComponent<GravityBody>(out GravityBody newObject))
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

    private void OnTriggerStay(Collider other)
    {
        if (canSwallow)
        {
            if (other.CompareTag("Object"))
            {
                if (other.TryGetComponent<GravityBody>(out GravityBody newObject))
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


}
