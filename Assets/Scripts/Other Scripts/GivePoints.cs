using UnityEngine;
using System.Collections;

// Giver point, når den rammes af en spiller.
// Der skal være en trigger collider på dette gameObject, for at det virker.
// Der skal være et UI med Points tilknyttet i scenen

public class GivePoints : MonoBehaviour {
	
	// Mængden af point, objektet giver.
	public int points = 5;

	// Angiver om objektet skal forsvinde, når det rammes
	public bool destroyedWhenHit = true;

    public AudioClip pickupSound;

	// En variable som holder en reference til points UI elementet's script
	private UI_GamePoints gamePoints;

    public ParticleSystem particles;

	void Start() {
		gamePoints = FindObjectOfType (typeof(UI_GamePoints)) as UI_GamePoints; // Sætter referencen til UI_GamePoints scriptet
	}

	//når noget colliderer med det her objekt bliver det betegnet "ting"
	private void OnTriggerEnter2D (Collider2D ting)
	{
		//Hvis "ting" har et tag, der hedder "Player" sendes Points til funktionen AddPoints i gamePoints på UI.
		if (ting.gameObject.tag == "Player")
		{
			if(gamePoints == null) {
				Debug.LogError ("Du mangler at tilføje \"Points\" til dit Game UI canvas. (Find objektet under \"Prefabs -> UI Objects -> Points\")");
			} else {
				gamePoints.AddPoints (points);
			}

            GetComponent<AudioSource>().Play();

            if (particles != null)
            {
                GameObject gm = Instantiate(particles, transform.position, particles.transform.rotation).gameObject;
                Destroy(gm, 1f);
            }
			if (destroyedWhenHit)
			{
				Destroy (gameObject);
			}
		}
	}
}