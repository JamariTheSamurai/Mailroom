using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehavior : MonoBehaviour
{
    private int walkSpeed = 8;
    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;
	void Start ()
	{

	}
	
	void Update ()
    {
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime, Space.World);
            transform.LookAt(bottom);
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime, Space.World);
            transform.LookAt(top);

        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime, Space.World);
            transform.LookAt(left);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime, Space.World);
            transform.LookAt(right);
        }
    }
}
