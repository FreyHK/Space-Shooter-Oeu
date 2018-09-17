using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Bomb : MonoBehaviour {

    public AudioClip pickupSound;

    public ParticleSystem particles;

    public LineRenderer lineRenderer;

    LayerMask enemyMask;
    CameraShaker cameraShaker;

    void Start() {
        cameraShaker = FindObjectOfType<CameraShaker>();
        enemyMask = LayerMask.GetMask("Enemy");
    }

    float Radius = 10f;

    //når noget colliderer med det her objekt bliver det betegnet "ting"
    private void OnTriggerEnter2D(Collider2D ting) {
        //Hvis "ting" har et tag, der hedder "Player" sendes Points til funktionen AddPoints i gamePoints på UI.
        if (ting.gameObject.tag == "Player") {
            //Find all enemies in range
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, Radius, enemyMask);

            for (int i = 0; i < cols.Length; i++) {
                //Draw line
                LineRenderer lr = Instantiate(lineRenderer, transform.position, Quaternion.identity);
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, cols[i].transform.position);
                //Remove line after .25f secs
                Destroy(lr.gameObject, .25f);

                //Destroy enemy
                Destroy(cols[i].gameObject);
            }

            //Sound effect
            GetComponent<AudioSource>().Play();

            //Particles
            if (particles != null) {
                GameObject gm = Instantiate(particles, transform.position, particles.transform.rotation).gameObject;
                Destroy(gm, 1f);
            }

            //Shake camera
            if (cameraShaker != null) {
                cameraShaker.ShakeOnce(15f, 3f, .5f, .5f);
            }

            //Destroy ourselves
            Destroy(gameObject);
        }
    }
}
