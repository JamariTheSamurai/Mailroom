using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabBehavior : MonoBehaviour
{
    [SerializeField]
    private bool somethingGrabbed;

    private float armDist = 5.0f;

    public Transform armPos;
    public Transform reach;

    private Ray grab;
    private RaycastHit whatIsGrabbed;

    private GameObject boxChild;
    private GameObject boxInFront;

	void Start ()
    {

	}
	
	void Update ()
	{
		grab = new Ray(new Vector3(transform.position.x, transform.position.y -1, transform.position.z), transform.forward * 5);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.forward * armDist, Color.red);

        if (Physics.OverlapBox(reach.position, new Vector3(1.0f, 2.0f, 2.0f), Quaternion.identity, 8) != null)
	    {
            
	        if (Input.GetKeyDown(KeyCode.Space))
	        {
	            if (!somethingGrabbed)
	            {
	                boxInFront.transform.parent = gameObject.transform;
	                boxChild = transform.GetChild(2).gameObject;
                    boxChild.transform.position = new Vector3(armPos.position.x, armPos.position.y, armPos.position.z + 0.5f);
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
	    Physics.Raycast(grab, out whatIsGrabbed);
        Debug.Log(whatIsGrabbed);

	    if (whatIsGrabbed.collider != null)
	    {
	        boxInFront = whatIsGrabbed.collider.gameObject;	        
	    }
	    else
	    {
	        boxInFront = null;
            Debug.Log("It's null");
	    }

	    }        Debug.Log(transform.GetChild(2) + " is child");
	}
}
