using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMailBehavior : MonoBehaviour
{
    [SerializeField]
    public bool isHeld;

    private Rigidbody rb;
	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        if (rb != null)
        {
            if (isHeld)
            {
                rb.isKinematic = true;
            }
            else
            {
                rb.isKinematic = false;
            }            
        }
	}

    public void OnTriggerEnter(Collider other)
    {

    }

    public void Grabbed()
    {
        isHeld = true;
    }

    public void SetDown()
    {
        isHeld = false;
    }
}
