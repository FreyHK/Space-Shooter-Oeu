using UnityEngine;
using System.Collections;

public class PointToPointMovement : MonoBehaviour {
	
	// Hastigheden, som objektet skal bevæge sig med.
	public float Speed=5;
	
	// Er objektet ved, at bevæge sig mod slut positionen?
	private bool modSlutPunkt = true;

    //De to objekter der skal bevæges imellem - kan være Empty GameObjects
    public GameObject startPunkt;
    public GameObject slutPunkt;



	void Start () {

		// Startpositionen sættes til første punkt
		transform.position = startPunkt.transform.position;
	}



	void Update () {
		
		// Bevægelse mod slut position:
		if (modSlutPunkt)
		{
            // Bevæg objektet mod slut positionen.
            transform.position = Vector3.MoveTowards(transform.position, slutPunkt.transform.position, Speed * Time.deltaTime);
			// Hvis vi er kommet til punktet, vender vi om.
			if (Vector3.Distance(slutPunkt.transform.position, transform.position) <= 0)
			{
				modSlutPunkt = false;
			}
		}
		
		// Bevægelse mod start positionen:
		else 
		{
            transform.position = Vector3.MoveTowards(transform.position, startPunkt.transform.position, Speed * Time.deltaTime);
            // Hvis vi er kommet til punktet, vender vi om.
            if (Vector3.Distance(startPunkt.transform.position, transform.position) <= 0)
			{
				modSlutPunkt = true;
			}
		}
		
	}
}
