using UnityEngine;
using System.Collections;

public class JumpMovement : MonoBehaviour {

	//Dette script får objektet til at hoppe fra side til side.
	//Objektet skal have rigidbody med gravity

	//Den kraft der hoppes op med
	public float JumpPower = 6f;

	//Den kraft der hoppes til siden med
	public float RightLeftSpeed = 3;

	//Den tid, der går imellem hoppene
	public float HoppeInterval = 4;
	
	//Hvis den er +1 hoppes mod højre; hvis den er -1 hoppes mod venstre
	public int RightLeft = 1;

	//Den tid der er gået siden sidste hop blev sat i gang
	private float TimeCounter;



	void Start () {

		//Tidstæller sættes til 0.
		TimeCounter = 0;
	
	}




	void Update () {

		//Hvis tidstæller overstiger intervaltid
		if (TimeCounter > HoppeInterval)
		{
			//Hop sættes i gang
			GetComponent<Rigidbody2D>().velocity = new Vector3 (RightLeftSpeed * RightLeft, JumpPower, 0f);

			//Tidstæller nulstilles
			TimeCounter = 0;

			//Hopperetning ændres
			RightLeft *= -1;
		}

		else
		{
			//Tidstæller øges med tiden siden sidste frame
			TimeCounter += Time.deltaTime;
		}	
	}
}
