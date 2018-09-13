using UnityEngine;
using System.Collections;
	
// Destruerer objektet dette script ligger p� n�r det bliver r�rt af en spiller.
// Destruktionen kan udskydes med Delay sekunder.
// Der skal v�re en collider p� dette gameObject.

public class DestroyWhenHit : MonoBehaviour
{
	public float Delay;

	// Bliver udf�rt, n�r noget rammer objektet.
	void OnCollisionEnter2D (Collision2D ting)
	{
		// Vi tjekker om det er spilleren der kolliderer med objektet, f�r vi destruerer
		if (ting.gameObject.tag == "Player")
		{
			Destroy (gameObject, Delay);
		}
	}
}
