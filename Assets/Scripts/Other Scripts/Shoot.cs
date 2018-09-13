using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    //Dette script sættes på det object som skal affyre bullets (sandsynligvis empty child på player)

    //bullet skal være en prefab med rigidbody (med gravity=0), CircleCollider2D og BulletMovement script
    public GameObject bullet;

    public float repeatSpeed = 0.5f;

    //bool, som afgør, om man kan blive ved at skyde ved at holde skydeknappen nede
    public bool continousShooting;

    private bool isShooting;

	// Use this for initialization
	void Start () {
        isShooting = false;
	}
	

	void Update () {

        if (continousShooting && !isShooting && Input.GetKey(KeyCode.Space))
        {
            isShooting = true;
            StartCoroutine(ShootBullet());
        }
		
        if (!continousShooting && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    IEnumerator ShootBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(repeatSpeed);
        isShooting = false;
    }
  
}
