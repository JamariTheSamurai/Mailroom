using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehavior : MonoBehaviour
{
    Vector3 movement;
    float speed = 8f;
    Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        movement = this.transform.position;
        playerRigidbody.position = this.transform.position;
        playerRigidbody.rotation = this.transform.rotation;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
        {
            Move(h, v);
            Rotate();
        }
       // Debug.Log("H is: " + h + "\nV is: " + v);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = /* movement.normalized */ movement * speed * Time.deltaTime;

        playerRigidbody.MovePosition(movement + playerRigidbody.position);
    }

    private void Rotate()
    {
        Quaternion rot = Quaternion.LookRotation(movement);
        //playerRigidbody.MoveRotation(rot);
        playerRigidbody.MoveRotation(Quaternion.Lerp(playerRigidbody.rotation, rot, 0.5f));
    }
}
