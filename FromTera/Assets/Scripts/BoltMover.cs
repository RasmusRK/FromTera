using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	public GameObject player;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		print (player.transform.forward);
		rb.velocity = player.transform.forward * speed;
	}
	

}
