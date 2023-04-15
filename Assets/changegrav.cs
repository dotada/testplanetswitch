using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changegrav : MonoBehaviour
{
    public float gravityDistance = 100f;
    public float gravityStrength = 9.8f;
    public LayerMask gravityLayer;

    private Rigidbody rb;
    private Transform currentGravityObject;
    private Quaternion bodyRotation;
    private Quaternion headRotation;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        bodyRotation = transform.rotation;
        headRotation = Quaternion.identity;  // No rotation for the head
    }

    void FixedUpdate() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, gravityDistance, gravityLayer);
        if (colliders.Length > 0) {
            currentGravityObject = colliders[0].transform;
            Vector3 gravityDirection = (currentGravityObject.position - transform.position).normalized;
            if (transform.position.y < -currentGravityObject.localScale.y / 2f) {
                gravityDirection = -gravityDirection;
            }
            rb.AddForce(gravityDirection * gravityStrength, ForceMode.Acceleration);

            // Calculate new orientation for the body
            Vector3 surfaceNormal = transform.position - currentGravityObject.position;
            Vector3 tangent = Vector3.Cross(surfaceNormal, transform.up);
            bodyRotation = Quaternion.LookRotation(tangent, surfaceNormal);

        } else {
            currentGravityObject = null;
        }

        // Combine body and head rotations
        transform.rotation = bodyRotation * headRotation;
    }

    public void SetHeadRotation(Quaternion rotation) {
        headRotation = rotation;
    }
}
