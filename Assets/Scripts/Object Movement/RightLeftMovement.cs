using UnityEngine;
using System.Collections;

public class RightLeftMovement : MonoBehaviour {

	// Afstanden, objektet skal bevæge sig.
	public float Distance;
	
	// Hastigheden, som objektet skal bevæge sig med.
	public float Speed;
	
	// Er objektet ved, at bevæge sig mod højre? Ved at vælge "false" vil objektet starte med at bevæge sig mod venstre
	public bool modHoejre = true;

	// Objektets startposition.
	private Vector3 originalPosition;
	


	void Start () 
	{
		// Startpositionen gemmes
		originalPosition = transform.position;		
	}



	void Update () {
		
		// Bevægelse til højre:
		if (modHoejre)
		{
			// Bevæg objektet mod højre.
			transform.Translate (Speed * Time.deltaTime, 0, 0);

			// Hvis vi er kommet for langt vender vi om.
			if (Vector3.Distance(transform.position, originalPosition) >= Distance)
			{
				originalPosition = transform.position;
				modHoejre = false;
			}
		}
		
		// Bevægelse til venstre:
		else 
		{
			transform.Translate (-Speed * Time.deltaTime, 0, 0);
			
			// Hvis vi er kommet for langt vender vi om.
			if (Vector3.Distance(transform.position, originalPosition) >= Distance)
			{
				originalPosition = transform.position;
				modHoejre = true;
			}
		}
		
	}
}
