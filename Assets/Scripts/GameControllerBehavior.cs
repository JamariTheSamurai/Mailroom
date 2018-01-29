using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerBehavior : MonoBehaviour
{
    private bool ended = false;

    [SerializeField]
    private int score;
    private int spamLimit = 10;
    private int curSpam;

    public Text scoreText;
    public Text spamText;

    public GameObject endScreen;
    public GameObject sounds;

	void Start ()
	{
	    sounds = gameObject;
	}

    public void Update()
    {
        scoreText.text = "Sorted: " + score;
        spamText.text = "Spam: " + curSpam +"/" + spamLimit;

        if (ended)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void GameOver()
    {
        endScreen.SetActive(true);
        ended = true;
        sounds.SendMessage("GameLost");
    }


    void MailSent (String type)
	{
	    if (type == "BasicMail")
	    {
	        score++;
	    }
        else if (type == "SpamMail")
	    {
	        score--;
	        curSpam++;
	        if (curSpam >= spamLimit)
	        {
	            GameOver();
	        }
	    }
        else if (type == "LoveMail")
	    {
	        
	    }
        else if (type == "VirusMail")
	    {
	        spamLimit -= 2;
	    }
        else if (type == "SpyMail")
	    {
	        
	    }
	}

    void MailDropped (String type)
	{
	    if (type == "BasicMail")
	    {
	        score++;
	    }
        else if (type == "SpamMail")
	    {
	        score++;
	    }
        else if (type == "LoveMail")
	    {
	        score += 10;
	        // 10 extra points
	    }
        else if (type == "VirusMail")
	    {
	        // nothing here
	    }
        else if (type == "SpyMail")
	    {
	        score += 20;
            // +20
        }
    }

    public void WrongBox(String type)
    {
        if (type == "BasicMail")
        {
            score-= 20;
        }
        else if (type == "SpamMail")
        {
            score--;
            curSpam++;
            if (curSpam >= spamLimit)
            {
                GameOver();
            }
        }
        else if (type == "LoveMail")
        {
            //nothing
        }
        else if (type == "VirusMail")
        {
            spamLimit -= 2;
            // maybe increase bad spawnrate eventually
            // easier to lower spam limit -2
            // manually increase all spawn possibly
        }
        else if (type == "SpyMail")
        {
           score -=25;
        }
    }
}
