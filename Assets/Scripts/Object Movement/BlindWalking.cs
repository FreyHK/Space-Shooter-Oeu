using UnityEngine;
using System.Collections;

public class BlindWalking : MonoBehaviour {

	/* Scriptet får et objekt til at gå til siden ind til den rammer noget. Så vender den om og går i den modsatte retning.
	Objektet skal have en rigidbody og collider.
	Objektet skal røre noget med tag "Ground" for at kunne gå.
	Scriptet er afhængig af at andre objekter har tags (Wall, Ground, Player).*/

	// Objektets walk hastighed
	public float WalkSpeed = 5;

	// Objektets nuværende hastighed (ved frit fald skal den være nul)
	private float currentSpeed;

	// Hvis true starter den med at gå mod venstre - ellers starter den mod højre
	public bool StartModVenstre = false;

	// variabel, som styrer om objekt bevæger sig mod højre eller venstre
	private int retning = 1;


	void Start ()
	{
		currentSpeed = WalkSpeed;

		if (StartModVenstre)
		{
			retning = -1;
		}
	}
	
	// I hver update flytter objektet sig med hastigheden currentSpeed på x-aksen (hastighed på y-aksen bibeholdes).
	void Update () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (currentSpeed*retning, GetComponent<Rigidbody2D>().velocity.y);
	}


	// Når objektet støder ind i noget, som hverken har tag "Ground" eller "Player" vender den om (retning 1 bevæger mod højre; retning -1 bevæger mod venstre).
	void OnCollisionEnter2D (Collision2D ting)
	{
		if (ting.gameObject.tag != "Ground" && ting.gameObject.tag != "Player")
		{
			retning *= -1;
		}
	}


	// Når objekt forlader noget med tag "Ground" sættes currentSpeed til 0 (hvilket betyder, at Update får den til at bevæge sig med hastighed 0 på x-aksen).
	void OnCollisionExit2D (Collision2D ting)
	{
		if (ting.gameObject.tag == "Ground")
		{
			currentSpeed = 0;
		}
	}


	// Sålænge objekt har kontakt til noget med tag "Ground" sættes dens hastighed lig med walkSpeed.
	void OnCollisionStay2D (Collision2D ting)
	{
		if (ting.gameObject.tag == "Ground")
		{
			currentSpeed = WalkSpeed;
		}
	}
}
