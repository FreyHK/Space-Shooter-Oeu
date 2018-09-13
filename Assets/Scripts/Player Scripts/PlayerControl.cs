using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	//Dette script lader spilleren styre figurens bevægelser med piletaster eller med adsw

	//MoveSpeed styrer hastigheden af spillerens bevægelse
	public float MoveSpeed= 5;

	//her kan man vælge om det skal være muligt at bevæge sig op/ned og højre/venstre
	//Hvis man kan bevæge sig op/ned, skal Gravity som regel sættes til nul
	public bool UpDown = false;
	public bool RightLeft = true;

	//værdi for hvor meget x og y skal ændres ved hver frame
	private float deltaX;
	private float deltaY;

	// Variable der holder en reference til Animator componentet på GameObjectet
	private Animator anim;

	void Start() {
		// Finder et Animator component på samme GameObject som dette script ligger på
		anim = GetComponent<Animator> ();
	}

	void Update () {
		//Hvis right/left bevægelse er tilvalgt beregnes deltaX. Input.GetAxis er en Unity-feature, som giver bløde bevægelser.
		if (RightLeft)
		{
			deltaX = MoveSpeed * Input.GetAxis("Horizontal");

			//Her ændres objektets hastighed på x-akse. Y-værdi fastholdes.
			GetComponent<Rigidbody2D>().velocity = new Vector2 (deltaX, GetComponent<Rigidbody2D>().velocity.y);
		}

		//Hvis right/left bevægelse er tilvalgt beregnes deltaY. Input.GetAxis er en Unity-feature, som giver bløde bevægelser.
		if (UpDown)
		{
			deltaY = MoveSpeed * Input.GetAxis("Vertical");

			//Her ændres objektets hastighed på y-akse. X-værdi fastholdes.
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, deltaY);
		}

		// Tjekker om vi har en gyldig reference til Animator componentet
		if(anim != null) {
			// Hvis characteren står stille, bliver Animatorens "Walking" variable sat til false, ellers til true
			if(deltaX == 0.0f) {
				anim.SetBool ("Walking", false);
			} else {
				anim.SetBool ("Walking", true);
			}
		}

	}
	
}