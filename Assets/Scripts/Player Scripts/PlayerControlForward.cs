using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlForward : MonoBehaviour {

    public TimedVariable PlayerSpeed = new TimedVariable();
    
    public float rotationSpeed = 100;

    Rigidbody2D body;

    public AudioClip pickupSound;

    TrailRenderer trail;

    private void Start() {
        trail = GetComponentInChildren<TrailRenderer>();
        body = GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().PlayOneShot(pickupSound);
    }

    public bool UseMouse = true;

    void Update () {
        if (UseMouse)
            MouseRotate();
        else
            ArrowKeyRotate();

        float speed = PlayerSpeed.GetValue(GameController.GameTime);
        //print("Time: " + GameController.GameTime + ", Speed: " + speed);
        body.MovePosition(body.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    Vector3 touchOrigin;
    //Is player touching screen/pressing mouse?
    bool steering = false;

    void MouseRotate () {
        //Player is not touching, don't steer
        if (!Input.GetMouseButton(0)) {
            steering = false;
            return;
        }else if (!steering) {
            touchOrigin = Input.mousePosition;
            steering = true;
        }

        Vector3 mouseDir = Input.mousePosition - touchOrigin;
            //Input.mousePosition - new Vector3(Screen.width/2f, Screen.height/2f);
        mouseDir.Normalize();
        Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, mouseDir);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            targetRot,
            rotationSpeed * Time.deltaTime);
    }

    void ArrowKeyRotate() {
        //Objekt roteres (styres af "til siden" knapper)
        float deltaRotation = -rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, deltaRotation));
    }

    public void SetPosition(Vector3 position) {
        trail.time = 0f;
        transform.position = position;
        Invoke("EnableTrail", 0.1f);
    }

    void EnableTrail () {
        trail.time = .3f;
    }
}
