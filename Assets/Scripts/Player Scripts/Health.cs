using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using EZCameraShake;
using System;

// Scriptet holder styr på Health og viser Health værdi på skærmen.
public class Health : MonoBehaviour {
	
	// Health værdi fra start.
	[Header("-- Object Health --")]
	public int healthValue = 100;

	[Header("-- When dead? --")]
	public bool loseGame = false;
	public bool destroyObject = false;

    public CameraShaker cameraShaker;
    public ParticleSystem deathParticles;

    public Action OnDeath;

    bool isDead = false;
    
    void Update () {
		if (healthValue <= 0 && !isDead) {
            isDead = true;

            //Spawn particles
            if (deathParticles != null) {
                GameObject gm = Instantiate(deathParticles, transform.position, deathParticles.transform.rotation).gameObject;
                Destroy(gm, 2f);
            }

            if (OnDeath != null)
                OnDeath();
		}
	}

	// Modtager damage værdi fra andre objekter, trækker damage fra Health.
	public void ReceiveDamage (int damage) 
	{
        if (cameraShaker != null)
        {
            cameraShaker.ShakeOnce(10f, 1f, 0f, .5f);
        }
		healthValue = healthValue - damage;
	}
}
