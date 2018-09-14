using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
		
        //Load first level (Game)
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(1);
    }
}
