using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        bool docked = GlobalVariables.docked;
    }

    // Update is called once per frame
    void Update()
    {
        if (dockActive == true)
        {
            if (GlobalVariables.docked == true)
            {
                GlobalVariables.canMove = false;
                StopCoroutine(TimerBattery.Timer());
                for (float i = 0; i < chargeTime; i++)
                {
                    chargeValue =+ GlobalVariables.currentTime;
                    Debug.Log("charging");
                }
                //StartCoroutine(dockCharge());
                GlobalVariables.canMove = true;
                StartCoroutine(dockCooldown());
                StartCoroutine(TimerBattery.Timer());
                Debug.Log("on charger");
            }
        }
    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.CompareTag("Dock"))
        {
            GlobalVariables.docked = true;
        }
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

    IEnumerator dockCharge()
    {
        chargeValue += GlobalVariables.currentTime;
        yield return new WaitForSeconds(chargeTime);
        Debug.Log("charging");
    }

    IEnumerator dockCooldown ()
    {
       yield return new WaitForSeconds(cooldownTime);
       dockActive = true;
       Debug.Log("dock started cooldown");
    }
}
