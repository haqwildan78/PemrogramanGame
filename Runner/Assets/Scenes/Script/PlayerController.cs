using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
   

    void Start()
    {

    }

    public float horizontalVelocity;
    public float jumpForce;
    void Update()
    {
        {
            if (Input.GetKeyDown("space"))
            { this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0)); }

            this.GetComponent<Rigidbody>().velocity =
                new Vector3(horizontalVelocity * Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z);
        }

    }
    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.name);
        if (c.gameObject.GetComponent<ObstacleController>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }

    }
}




