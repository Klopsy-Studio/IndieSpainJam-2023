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
    [SerializeField] AudioSource getEatenSound;

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

    public Collider floorCollider;

    [HideInInspector] public bool destroyOnArrival;
    [HideInInspector] public bool explosionOnArrival;
    [SerializeField] float explosionRange;
    [SerializeField] bool activateGizmos;

    [HideInInspector] public bool canPlayLandingSound;
    [SerializeField] AudioSource landingSound;
    public void Update()
    {
        if (!planetDetected && GameManager.instance.CurrentGameState != GameStates.Pause)
        {
            model.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        }

        if (!detected)
        {
            if (Physics.Raycast(transform.position, -transform.position * 1000f, out hit, Mathf.Infinity, 8))
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
            floorCollider.enabled = false;

            landingSound.Play();

            if (explosionOnArrival)
            {
                Collider[] explosion = Physics.OverlapSphere(transform.position, explosionRange);

                for (int i = 0; i < explosion.Length; i++)
                {
                    if (explosion[i].CompareTag("Player"))
                    {
                        GameManager.instance.playerCharacter._playerCharacterDeath.HitPlayer();
                        DeactivateItself();
                    }
                }

            }
            if (destroyOnArrival)
            {
                int chance = Random.Range(0, 100);
                
                if(chance <= 10)
                {
                    DeactivateItself();
                }
            }
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
        AudioManager.instance.Play("Eat");
        GameObject swallowPoof = Instantiate(swallowPoofVFX, transform);
        swallowPoof.transform.localScale = explosionVFX.transform.localScale;
        swallowPoof.transform.parent = null;
        poolManager.ReturnObjToPool(this.gameObject);
    }


    private void OnDrawGizmos()
    {
        if (activateGizmos)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, explosionRange);
        }
    }

}
