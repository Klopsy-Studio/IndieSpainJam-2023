using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10f;
    public void Attract(Transform bodyTransform, Rigidbody bodyRigid)
    {
        Vector3 gravityUp = (bodyTransform.position - transform.position).normalized;
        Vector3 bodyUp = bodyTransform.up;

        bodyRigid.AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * bodyTransform.rotation;
        bodyTransform.rotation = Quaternion.Slerp(bodyTransform.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
