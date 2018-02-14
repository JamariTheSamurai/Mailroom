using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBehavior : MonoBehaviour
{

	void Start ()
    {
		
	}

    public void MainStart()
    {
        SceneManager.LoadScene("Survival");
    }
}
