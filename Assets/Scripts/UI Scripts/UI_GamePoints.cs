using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePoints : MonoBehaviour {

	public Text pointsText;

	private static int points = 0;

	void Start() {
		pointsText.text = points.ToString (); // Display the current points
	}
    
	public void AddPoints(int pointsToAdd) {
		points += pointsToAdd;
		pointsText.text = points.ToString ();
	}

	public void ResetPoints() {
		points = 0;
	}

	public int GetPoints() {
		return points;
	}
}
