using UnityEngine;
using System.Collections;
	
// Destruerer objektet dette script ligger på når det bliver rørt af en spiller.
// Destruktionen kan udskydes med Delay sekunder.
// Der skal være en collider på dette gameObject.

public class DestroyWhenHit : MonoBehaviour
{
	public float Delay;

	// Bliver udført, når noget rammer objektet.
	void OnCollisionEnter2D (Collision2D ting)
	{
		// Vi tjekker om det er spilleren der kolliderer med objektet, før vi destruerer
		if (ting.gameObject.tag == "Player")
		{
			Destroy (gameObject, Delay);
		}
	}
}
