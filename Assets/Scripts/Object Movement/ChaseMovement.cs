using UnityEngine;
using System.Collections;

// Scriptet får objektet til, at følge efter et andet objekt, med en bestemt hastighed.
public class ChaseMovement : MonoBehaviour {
	
	// Objektet, som vi skal følge efter.
	public GameObject Target;

	// Hastigheden, som vi skal bevæge os med.
	public float MovementSpeed = 2f;
		

    public enum AI_Type {
        Follow,
        CopyDirection,
        RandomFollow
    }

    public AI_Type AI = AI_Type.RandomFollow;

    private void Start()
    {

        //AI = (AI_Type)Random.Range(0, 3);
            
    }

    void Update () {

        // Beregn retningen mod spilleren.
        Vector3 retning = Vector3.zero;

        switch (AI)
        {
            case AI_Type.Follow:
                retning = Follow();
                break;
            case AI_Type.CopyDirection:
                retning = CopyDirection();
                break;
            case AI_Type.RandomFollow:
                retning = RandomFollow();
                break;
        }
            
		
		// Bevæger objektet i den beregnede retning, med den indstillede hastighed.
		transform.position += retning * MovementSpeed * Time.deltaTime;
	}

    Vector3 Follow () {
        Vector3 retning = Target.transform.position - transform.position;

        // Normalize betyder at vektoren gives længden 1, men retning bibeholdes.
        retning.Normalize();

        return retning;
    }

    Vector3 CopyDirection()
    {
        Vector3 retning = Target.transform.position - transform.position;

        // Normalize betyder at vektoren gives længden 1, men retning bibeholdes.
        retning.Normalize();

        return retning;
    }

    Vector3 RandomFollow()
    {
        print("RandomFollow");
        Vector3 retning = Target.transform.position - transform.position;

        retning *= .5f;
        Vector2 random = (Vector2)Random.onUnitSphere;
        retning += (Vector3)random * .5f;

        // Normalize betyder at vektoren gives længden 1, men retning bibeholdes.
        retning.Normalize();

        return retning;
    }
}
