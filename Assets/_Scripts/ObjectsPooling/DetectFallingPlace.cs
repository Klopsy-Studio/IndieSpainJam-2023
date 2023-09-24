using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFallingPlace : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    [SerializeField] GameObject marker;

    bool detected;

    public List<GameObject> objectPool;

    private void Start()
    {
       
    }

    public void Update()
    {
        if (!detected)
        {
            if (Physics.Raycast(transform.position, -transform.position * 1000f, out hit))
            {
                marker = Instantiate(marker, hit.point, Quaternion.identity);
                GameObject body = Instantiate(objectPool[Random.Range(0, objectPool.Count)], transform.position, Quaternion.identity);
                body.transform.parent = null;
                body.GetComponent<Rigidbody>().AddTorque(new Vector3(150, 150, 150), ForceMode.Force);

                Destroy(gameObject);
                detected = true;
            }
        }
    }
}
