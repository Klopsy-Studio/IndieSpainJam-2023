using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public PoolManager poolManager { get; set; }

    [SerializeField] float velocity = 2f;

    RaycastHit raycastHit;
    RaycastHit hit;
    bool planetDetected;

    public GameObject markerPrefab;

    GameObject markerInGame;
    bool detected;
    public void Update()
    {
        if (!planetDetected)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, velocity);
            Vector3 dir = Vector3.zero - transform.position;
            if (Physics.Raycast(transform.position, dir, out raycastHit, 2f))
            {
                GetComponent<Rigidbody>().useGravity = true;
                Destroy(markerInGame);
                planetDetected = true;
            }
        }

        if (!detected)
        {
            if (Physics.Raycast(transform.position, -transform.position * 1000f, out hit))
            {
                markerInGame = Instantiate(markerPrefab, hit.point, Quaternion.identity);
                GetComponent<Rigidbody>().AddTorque(new Vector3(150, 150, 150), ForceMode.Force);

                detected = true;
            }
        }

    }

    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;

    }
    public void Init(PoolManager _poolManager)
    {
        poolManager = _poolManager;
    }

    public void DeactivateItself()
    {
        poolManager.ReturnObjToPool(this.gameObject);
    }

    
}
