using UnityEngine;
using System.Collections;

public class PointToPointOneWay : MonoBehaviour {
	
	// Hastigheden, som objektet skal bevæge sig med.
	public float Speed=5;
	
	//De to objekter der skal bevæges imellem - kan være Empty GameObjects
	public GameObject startPunkt;
	public GameObject slutPunkt;


	void Start () {

		// Objektet placeres ved startpunktet
		transform.position = startPunkt.transform.position;
	}
	

	
	// Update køres hver gang der tegnes et nyt billede.
	void Update () {
		
		// Bevæg objektet mod slut positionen.
		transform.position = Vector3.MoveTowards(transform.position, slutPunkt.transform.position, Speed * Time.deltaTime);

		// Hvis vi er kommet til punktet, starter vi forfra.
		if (Vector3.Distance(slutPunkt.transform.position, transform.position) <= 0)
		{
			transform.position = startPunkt.transform.position;
		}
	}
}
