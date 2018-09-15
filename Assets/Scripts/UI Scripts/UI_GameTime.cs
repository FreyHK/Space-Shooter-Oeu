using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameTime : MonoBehaviour {

	public Text timerText;
	public bool displayFinalTime = false;

	private static float timer = 0.0f;

	void Start() {
		if(displayFinalTime) {
			timerText.text = timer.ToString ("F2");
		}
	}

	void Update () {
		if (!displayFinalTime) {
			timer += Time.deltaTime; // Counts the time passed since last frame and adds
			timerText.text = timer.ToString ("F2"); // Displays the time spent with 2 digits (e.g. "215.23" or "5.80")
		}
	}

    public void ResetTimer () {
        timer = 0f;
    }
}
