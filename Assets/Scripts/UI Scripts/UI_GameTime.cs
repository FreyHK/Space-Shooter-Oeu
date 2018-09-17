using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameTime : MonoBehaviour {

	public Text timerText;
	public bool displayFinalTime = false;
    
	void Start() {
		if(displayFinalTime) {
			timerText.text = GameController.GameTime.ToString ("F2");
		}
	}

	void Update () {
		if (!displayFinalTime) {
			timerText.text = GameController.GameTime.ToString ("F2"); // Displays the time spent with 2 digits (e.g. "215.23" or "5.80")
		}
	}
}
