using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    /* 
     * Skal sidde på bullet prefab
     * Spiller skal hedde "PlayerForward"
     * Walls skal have tag "Wall"
     * Fjender skal have tag "Enemy"
     */

    public float bulletSpeed = 20f;

    private GameObject player;

    //den tid der går inden bullet får collider (så den ikke colliderer med det, der afskyder bullet)
    public float delay = 0.1f;


	// Use this for initialization
	void Start () {

        GetComponent<CircleCollider2D>().enabled = false;

        //bullet afsendes i den retning, som player peger med hastighed bulletSpeed
        player = GameObject.Find("PlayerForward");
        GetComponent<Rigidbody2D>().velocity = player.transform.up * bulletSpeed;

        StartCoroutine (ColliderDelay ());
    }

    // Update is called once per frame
    void Update () {
		
	}


    void OnCollisionEnter2D (Collision2D ting)
    {
        if (ting.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (ting.gameObject.tag == "Enemy")
        {
            Destroy(ting.gameObject);
        }
    }


    public IEnumerator ColliderDelay ()
    {
        yield return new WaitForSeconds (delay);
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
