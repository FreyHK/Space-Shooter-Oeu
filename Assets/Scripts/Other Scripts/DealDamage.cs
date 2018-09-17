using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {
	// Giver damage, når den rammes af en spiller
	// Der skal være en collider (ikke trigger) på dette gameObject for, at det virker.
 
	//Størrelsen af den skade, objektet giver
	public int Damage = 10;

    public ParticleSystem particles;
	
	//når noget colliderer med det her objekt bliver det betegnet "ting"
	private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag != "Player" && col.gameObject.tag != "Rock" && col.gameObject.tag != "Enemy")
            return;
        
		//Hvis "ting" har et tag, der hedder "Player" sendes Damage til funktionen ReceiveDamage i scriptet Health på Player
		if (col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<Health>().ReceiveDamage(Damage);
        }

        //Destroy rock if that's what we hit
        //if (col.gameObject.tag == "Rock")
        //    Destroy(col.gameObject);
        
        //Destroy enemy (ourselves)
        Destroy(gameObject);
	}

    private void OnDestroy() {
        //Spawn particles
        if (particles != null) {
            GameObject gm = Instantiate(particles, transform.position, particles.transform.rotation).gameObject;
            Destroy(gm, 1f);
        }
    }
}
