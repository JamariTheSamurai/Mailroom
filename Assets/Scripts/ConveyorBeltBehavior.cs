using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltBehavior : MonoBehaviour
{
    private float moveSpeed =5;
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "BasicMail" ||
                other.tag == "SpamMail" ||
                    other.tag == "LoveMail" ||
                        other.tag == "SpyMail" ||
                            other.tag == "VirusMail")
        {
            other.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }
    }
}
