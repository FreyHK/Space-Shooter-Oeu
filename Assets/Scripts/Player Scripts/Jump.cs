using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	//Dette script lader spilleren hoppe med figuren.
	//Figuren skal (udover sin almindelige collider) have en triggecollider lige under sig (til at tjekke om den står på en ground)
	//De ting, figuren skal kunne hoppe på, skal have et tag kaldet "Ground"

	//Her vælger man, om der kan hoppes i luften
	public bool DoubleJump = false;
	public bool MultiJump = false;

	//Den kraft man hopper med
	public float JumpPower = 8f;

	//fortæller om figuren er grounded
	private bool grounded;

	//holder styr på om muligheden for doublejump er benyttet
	private bool DoubleJumpUsed = false;

	// Variable der holder en reference til Animator componentet på GameObjectet
	private Animator anim;

	void Start() {
		// Finder et Animator component på samme GameObject som dette script ligger på
		anim = GetComponent<Animator> ();

		// Player sættes fra start til ikke at være grounded
		grounded = false;
	}



	void Update () {
		//Hvis der trykkes Space OG figuren er enten grounded, klar til doublejump eller multijump er tilsluttet, skal figuren hoppe
		if (Input.GetKeyDown(KeyCode.Space) && (grounded || DoubleJump && !DoubleJumpUsed || MultiJump))
		{
			//Ændrer figurens hastighed: x beholdes, y sættes til JumpPower, z sættes til 0
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, JumpPower);

			// Tjekker om vi har en gyldig reference til Animator componentet
			if (anim != null) {
				// Afspiller Jump animationen ved at trigger Animatorens "Jump" variable
				anim.SetTrigger ("Jump");
			}

			//Grounded hop gør doublejump ubrugt; ikke grounded hop gør doublejump brugt
			if (grounded)
			{
				DoubleJumpUsed = false;
			}
			else
			{
				DoubleJumpUsed = true;
			}
		}

		// Tjekker om vi har en gyldig reference til Animator componentet
		if(anim != null) {
			// Animatorens "InAir" variable sat til det modsatte af hvad 'grounded' er. Dette sørger for at Animatoren ved om characteren er i luften eller ej
			anim.SetBool ("InAir", !grounded);
		}
	}

	//Når en Ground forlader triggerzone gøres player ikke-grounded
	void OnTriggerExit2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			grounded = false;
		}
	}
	
	//Når en Ground befinder sig i triggerzone gøres player grounded
	void OnTriggerStay2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}
}
