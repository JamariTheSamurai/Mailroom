using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabTry2 : MonoBehaviour
{
    private bool somethingGrabbed;

    public Transform armPos;


    public GameObject player;
    private GameObject boxChild;
    public GameObject boxInFront;

    void Start ()
    {
    }

    public void Update()
    {
        if (boxInFront != null)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (!somethingGrabbed)
                {
                    somethingGrabbed = true;
                    boxChild = boxInFront;
                    boxChild.SendMessage("Grabbed");
                    boxChild.transform.parent = player.transform;
                    boxChild.transform.position = transform.position;
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
	
	public void OnTriggerEnter (Collider other)
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
	public void OnTriggerExit (Collider other)
	{
	    if (other.tag == "BasicMail" ||
	        other.tag == "SpamMail" ||
	        other.tag == "LoveMail" ||
	        other.tag == "SpyMail" ||
	        other.tag == "VirusMail")
	    {
	        StartCoroutine(EasyHandling());

	    }


    }

    IEnumerator EasyHandling()
    {
        if (!somethingGrabbed)
        {
            yield return new WaitForSeconds(0.4f);
            boxInFront = null;            
        }
        else if (somethingGrabbed)
        {
            boxInFront = boxChild;
        }
    }
}
