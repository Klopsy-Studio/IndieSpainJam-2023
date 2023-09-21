using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public PoolManager poolManager { get; set; }

    [Header("References")]
    [SerializeField] Rigidbody rigid;
    [SerializeField] GameObject model;
    public GameObject markerPrefab;
    [HideInInspector] public GameObject markerInGame;
    public GravityBody objectBody;
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private GameObject swallowPoofVFX;

    [Header("Parameters")]
    [SerializeField] float velocity = 2f;
    [SerializeField] float maxRotationForce = 2f;
    private float xAngle;
    private float yAngle;
    private float zAngle;

    RaycastHit hit;
    bool planetDetected = false;
    bool detected;

    [HideInInspector] public bool falling;

    public void Update()
    {
        if (!planetDetected)
        {
            model.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        }

        if (!detected)
        {
            if (Physics.Raycast(transform.position, -transform.position * 1000f, out hit))
            {
                markerInGame = Instantiate(markerPrefab, hit.point, Quaternion.identity);
                detected = true;
            }
        }

    }
    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        objectBody.EnableAttraction();

        xAngle = Random.Range(-maxRotationForce, maxRotationForce);
        yAngle = Random.Range(-maxRotationForce, maxRotationForce);
        zAngle = Random.Range(-maxRotationForce, maxRotationForce);

        falling = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Planet") && !planetDetected)
        {
            Destroy(markerInGame);
            planetDetected = true;

            PlayHitVFX();
            falling = false;
        }
    }

    private void PlayHitVFX()
    {
        explosionVFX.SetActive(true);

        hitVFX.transform.position = hit.point;
        hitVFX.SetActive(true);
    }

    public void Init(PoolManager _poolManager)
    {
        poolManager = _poolManager;
    }

    public void DeactivateItself()
    {
        GameObject swallowPoof = Instantiate(swallowPoofVFX, transform);
        swallowPoof.transform.localScale = explosionVFX.transform.localScale;
        swallowPoof.transform.parent = null;
        poolManager.ReturnObjToPool(this.gameObject);
    }

    
}
