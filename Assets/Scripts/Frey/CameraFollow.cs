using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    Vector2 offset;

	void Start () {
        offset = transform.position - target.position;
	}
	
	void LateUpdate () {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10f);
	}
}
