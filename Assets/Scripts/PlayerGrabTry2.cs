using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabTry2 : MonoBehaviour
{
    private bool somethingGrabbed;

    public Transform armPos;


    public GameObject player;
    private GameObject boxChild;
    private GameObject boxInFront;

    void Start ()
    {
    }

    public void Update()
    {
        if (boxInFront != null)
        {
            if (Input.GetAxis("Jump") > 0)
            {
                if (!somethingGrabbed)
                {
                    boxInFront.transform.parent = player.transform;
                    boxChild = player.transform.GetChild(2).gameObject;
                    boxChild.transform.position = transform.position;
                    boxChild.SendMessage("Grabbed");
                    somethingGrabbed = true;
                }
                else
                {
                    somethingGrabbed = false;
                    boxChild.SendMessage("SetDown");
                    boxChild.transform.parent = null;
                }

            }
            
        }
        
    }
	
	public void OnTriggerStay (Collider other)
	{
	    if (other.tag == "BasicMail" ||
	        other.tag == "SpamMail" ||
	        other.tag == "LoveMail" ||
	        other.tag == "SpyMail" ||
	        other.tag == "VirusMail")
	    {
            boxInFront = other.gameObject;
	        
	    }


    }
}
