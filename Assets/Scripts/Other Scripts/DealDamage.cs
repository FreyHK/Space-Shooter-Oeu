using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {
	// Giver damage, når den rammes af en spiller
	// Der skal være en collider (ikke trigger) på dette gameObject for, at det virker.
 
	//Størrelsen af den skade, objektet giver
	public int Damage = 10;

    public ParticleSystem particles;
	
	//når noget colliderer med det her objekt bliver det betegnet "ting"
	private void OnCollisionEnter2D (Collision2D ting)
    {
        if (ting.gameObject.tag != "Player" && ting.gameObject.tag != "Rock" && ting.gameObject.tag != "Enemy")
            return;
        
		//Hvis "ting" har et tag, der hedder "Player" sendes Damage til funktionen ReceiveDamage i scriptet Health på Player
		if (ting.gameObject.tag == "Player")
		{
			ting.gameObject.GetComponent<Health>().ReceiveDamage(Damage);
        }

        //Destroy rock if that's what we hit
        if (ting.gameObject.tag == "Rock")
            Destroy(ting.gameObject);

        //Spawn particles
        if (particles != null)
        {
            GameObject gm = Instantiate(particles, transform.position, particles.transform.rotation).gameObject;
            Destroy(gm, 1f);
        }

        //Destroy enemy (ourselves)
        Destroy(gameObject);
	}
}
