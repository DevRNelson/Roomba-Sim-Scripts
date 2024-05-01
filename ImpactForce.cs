using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactForce : MonoBehaviour
{
    public float horizontalForceMagnitude;
    public float verticalForceMagnitude;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null && collision.gameObject != gameObject)
        {
            Vector3 impactDirection = collision.contacts[0].point - transform.position;
            impactDirection.y = 0; // Set the y component to 0 to prevent upward force
            collision.rigidbody.AddForce(impactDirection.normalized * horizontalForceMagnitude, ForceMode.Impulse);
            collision.rigidbody.AddForce(Vector3.up * verticalForceMagnitude, ForceMode.Impulse);
        }
    }
}
