using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlForward : MonoBehaviour {

    public float speedForward = 5;
    public float rotationSpeed = 100;

    Rigidbody2D body;

    public AudioClip pickupSound;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().PlayOneShot(pickupSound);
    }

    void Update () {
        //Objekt roteres (styres af "til siden" knapper)
        float deltaRotation = -rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Rotate(new Vector3 (0,0,deltaRotation));

        body.MovePosition(body.position + (Vector2)transform.up * speedForward * Time.deltaTime);
    }
}
