using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	private float speed = 10f;

	void Start () {
	}
	
	void Update () {
		transform.Rotate (Vector3.up, speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other){
		Destroy (other.gameObject);
		Debug.Log ("HIT! by " + other.gameObject.name);
		Destroy (this.gameObject);
	}
}
