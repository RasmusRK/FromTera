using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour {

	public GameObject shotType;
	public float shotDelay = 0.01f;

	private GameObject player;
	private float nextShotTime = 0f;

	void Start () {
		player =  GameObject.FindGameObjectWithTag("Player");	
	}
	
	void Update () {		
		if (Time.time > nextShotTime ) {
			nextShotTime += shotDelay;
			GameObject shot = Instantiate (shotType, transform.position, transform.rotation);
			shot.GetComponent<Rigidbody2D> ().AddForce (transform.forward * 50);
		}
	}
}
