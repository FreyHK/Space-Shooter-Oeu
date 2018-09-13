using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using EZCameraShake;

// Scriptet holder styr på Health og viser Health værdi på skærmen.
public class Health : MonoBehaviour {
	
	// Health værdi fra start.
	[Header("-- Object Health --")]
	public int healthValue = 100;

	[Header("-- When dead? --")]
	public bool loseGame = false;
	public bool destroyObject = false;

    public CameraShaker cameraShaker;

	// void Update: Hver gang der tegnes et nyt billede.
	void Update () {
		// Hvis Health er mindre eller lig med 0 går spillet videre til scenen "Lose".
		if (healthValue <= 0)
		{
			if (loseGame) {
				SceneManager.LoadScene ("Lose");
			}
			if(destroyObject) {
				KillMe (); // Kalder funktionen "KillMe"
			}
		}
	}

	// Modtager damage værdi fra andre objekter, trækker damage fra Health.
	public void ReceiveDamage (int damage) 
	{
        if (cameraShaker != null)
        {
            cameraShaker.ShakeOnce(10f, 1f, 0f, .5f);
        }
		healthValue = healthValue - damage;
	}

	// Funktion som bruges når objektet skal ødelægges.
	// Her kan man fx tilføje en animation afspilning inden man kalder Destroy() funktionen
	private void KillMe() {
		Destroy (gameObject);
	}

}
