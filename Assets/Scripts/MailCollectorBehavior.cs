using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailCollectorBehavior : MonoBehaviour
{
    private GameObject gameController;

	void Start ()
    {
		gameController = GameObject.FindWithTag("GameController");
	}
	
	void Update ()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BasicMail")
        {
           // gameController.SendMessage("MailSent", other.tag);
           // gameController.SendMessage("PlaySuccess");
            //Destroy(other.attachedRigidbody, 5.0f);
        }
        if (other.tag == "SpamMail")
        {
            gameController.SendMessage("MailSent", other.tag);
            gameController.SendMessage("PlayFailure");
           // Destroy(other.attachedRigidbody, 5.0f);
        }
        if (other.tag == "VirusMail")
        {
            gameController.SendMessage("MailSent", other.tag);
           // Destroy(other.gameObject);
        }
        if (other.tag == "SpyMail")
        {
          //  gameController.SendMessage("MailSent", other.tag);
          //  Destroy(other.gameObject);
        }
        if (other.tag == "LoveMail")
        {
           // gameController.SendMessage("MailSent", other.tag);
           // Destroy(other.gameObject);
        }
    }
}
