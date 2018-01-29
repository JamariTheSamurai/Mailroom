using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailSpawnerBehavior : MonoBehaviour
{
    private float spawnTimer;
    private float timerMult =1;

    private int mailToSpawn;
    private int spawned = 0;

    public GameObject basicMail;
    public GameObject spamMail;
    public GameObject loveMail;
    public GameObject spyMail;
    public GameObject virusMail;

	void Start ()
	{
	    spawnTimer = 1;
	}
	
	void Update ()
	{
	    spawnTimer -= timerMult * Time.deltaTime;
        mailToSpawn = Random.Range(1, 49);

	    if (Input.GetKeyDown(KeyCode.Q))
	    {
	        spawnTimer = 0.1f;
	    }
        if (spawnTimer <= 0)
        {
            if (mailToSpawn >=1 && mailToSpawn <= 24)
            { 
                // normal 50%
                Instantiate(basicMail, transform.position, Quaternion.identity);
         //   Instantiate(spamMail, transform.position, Quaternion.identity);
            }
            else if (mailToSpawn >=25 && mailToSpawn <= 34)
            {
                //spam 20%
                Instantiate(spamMail, transform.position, Quaternion.identity);
            }
            else if (mailToSpawn >= 35 && mailToSpawn <= 39)
            {
                //love 10%
                 Instantiate(loveMail, transform.position, Quaternion.identity);
               
            }
            else if (mailToSpawn >= 40 && mailToSpawn <= 44)
            {
                // virus 10%
                Instantiate(virusMail, transform.position, Quaternion.identity);
            }
            else if (mailToSpawn >= 45 && mailToSpawn <= 49)
            {
                //spy 10%
                Instantiate(spyMail, transform.position, Quaternion.identity);
            }
            spawnTimer = 5;
            spawned++;
        }

	    if (spawned == 7)
	    {
	        if (timerMult <= 3.3)
	        {
	            timerMult += 0.3f;
	            spawned = 1;
	        }
	        else
	        {
	            timerMult = 3.3f;
	        }
	    }
    }
}
