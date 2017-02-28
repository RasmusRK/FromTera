using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour {

	public GameObject shotType;
	public float shotDelay = 0.01f;
	public float firstShotAfter = 0f;

	private GameObject player;

	void Start () {
		player =  GameObject.FindGameObjectWithTag("Player");	
	}
	
	void Update () {		
		if (Time.time > firstShotAfter ) {
			firstShotAfter += shotDelay;
			GameObject shot = Instantiate (shotType, transform.position, transform.rotation);

			shot.GetComponent<Rigidbody2D> ().AddForce (transform.forward * 50);
		}
	}
}
