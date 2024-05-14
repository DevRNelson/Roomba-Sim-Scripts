using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float horizontalForceMagnitude;
    public float verticalForceMagnitude;

    PlayerMovement playerMovement;
    [SerializeField] GameObject player;

    public float chargeValue;
    public float chargeTime;
    public float cooldownTime;
    public bool dockActive = true;

    private bool charging = false;
    private bool onCooldown = false;
 

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Cache PlayerMovement component
    }

    void Update()
    {
        if (dockActive && !onCooldown)//detects if the device is docked and then begins charging 
        {
            if (GlobalVariables.docked && !charging)
            {
                GlobalVariables.canMove = false;
                charging = true;

                StartCoroutine(ChargeForTenSeconds());
            }
        }
    }

    IEnumerator ChargeForTenSeconds() //self explanatory name honestly
    {
        float elapsedTime = 0f;

        while (elapsedTime < 10f) // Charge for ten seconds
        {
            GlobalVariables.currentTime += chargeValue;
            Debug.Log("Charging...");
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        charging = false;
        GlobalVariables.docked = false;
        GlobalVariables.canMove = true;
        StartCoroutine(StartCooldown()); // Start the cooldown
        Debug.Log("Finished charging");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dock") && !onCooldown)
        {
            GlobalVariables.docked = true;
            Debug.Log("Docked");
        }
    }

    IEnumerator StartCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
        Debug.Log("Cooldown finished");
    }

     //Improved physics
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
