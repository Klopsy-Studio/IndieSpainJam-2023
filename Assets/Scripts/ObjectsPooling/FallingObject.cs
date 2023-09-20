using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public PoolManager poolManager { get; set; }

    [SerializeField] float velocity = 2f;

    RaycastHit raycastHit;
    RaycastHit hit;
    bool planetDetected = false;

    public GameObject markerPrefab;

    GameObject markerInGame;
    bool detected;

    public GravityBody objectBody;
    [SerializeField] Rigidbody rigid;
    [SerializeField] GameObject model;
    public void Update()
    {
        if (!planetDetected)
        {
            model.transform.Rotate(2, 2, 2, Space.Self);
            //Debug.Log("Detected");
            //rigid.AddForce(-transform.position, ForceMode.Force);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Planet"))
        {
            Test();
        }
    }

    public void Test()
    {
        Destroy(markerInGame);
        planetDetected = true;
    }
    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        objectBody.EnableAttraction();
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
