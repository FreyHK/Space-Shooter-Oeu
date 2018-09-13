using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinCondition : MonoBehaviour {
	// Scriptet tjekker for om man har vundet spillet
	
	// Antal point der skal til for at vinde spillet
	public int winValue = 100;

	// En variable som holder en reference til points UI elementet's script
	private UI_GamePoints gamePoints; 

	void Start () {
		//Score sættes fra start til 0
		gamePoints = FindObjectOfType (typeof(UI_GamePoints)) as UI_GamePoints;

		if(gamePoints == null) {
			Debug.LogError ("Du mangler at tilføje \"Points\" til dit Game UI canvas. (Find objektet under \"Prefabs -> UI Objects -> Points\")");
		} else {
			gamePoints.ResetPoints (); // Nulstiller points i starten af spillet
		}
	}

	void Update () {
		// Tjekker om der er et UI_GamePoints script fundet i scenen
		if(gamePoints != null) {
			// Hvis antal point er større eller lig med winValue går spillet videre til scenen "Win"
			if (gamePoints.GetPoints () >= winValue)
			{
				SceneManager.LoadScene ("Win");
			}
		}
	}
		

}
