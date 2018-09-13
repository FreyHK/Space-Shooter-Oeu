using UnityEngine;
using System.Collections;

public class CircularMovement : MonoBehaviour {
	//Dette script får objekt til at bevæge sig i en cirkel
	//Det skal have tilføjet et centrum for at virke
	//Man kan vælge om objektet skal bevæge sig med eller mod uret
	//Objektet vil altid starte til højre for centrum

	//Centrum for cirkelbevægelsen
	public Transform Centrum;

	//Hastighed (afhænger dog også af radius
	public float Speed = 5f;

	//Bevægelse med uret?
	public bool MedUret = true;

	//værdi til sørge for rigtig bevægelsesretning
	private int medUret;

	private Vector3 startPosition;
	private float radius;

	// Use this for initialization
	void Start () {
	
		//Beregning af radius
		startPosition = transform.position;
		Vector2 radiusVector = new Vector2 (startPosition.x - Centrum.position.x, startPosition.y - Centrum.position.y);
		radius = radiusVector.magnitude;



	}
	
	// Update is called once per frame
	void Update () {

		if (MedUret)
		{
			medUret = -1;
		}

		else
		{
			medUret = 1;
		}

		//Beregning af ny position
		transform.position = Centrum.position + new Vector3 (Mathf.Cos((Time.timeSinceLevelLoad)*Speed) * radius, medUret * Mathf.Sin((Time.timeSinceLevelLoad)*Speed) * radius, 0f);                                  

	}
}
