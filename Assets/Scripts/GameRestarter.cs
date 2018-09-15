using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {

        //Load first level (Game)
        if (Input.GetKeyDown(KeyCode.Space)) {
            UI_GamePoints points = FindObjectOfType<UI_GamePoints>();
            if (points != null)
                points.ResetPoints();

            UI_GameTime time = FindObjectOfType<UI_GameTime>();
            if (time != null)
                time.ResetTimer();
            
            SceneManager.LoadScene(1);
        }
    }
}
