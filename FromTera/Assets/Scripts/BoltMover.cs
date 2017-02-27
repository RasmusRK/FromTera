using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();

		rb.AddForce (transform.parent.forward * speed);
		//rb.velocity = transform.parent.forward* speed;
	}

	void OnCollisionEnter2D(Collision2D coll)  
	{
		//if (coll.transform.name == "wall") 
		//{
			Destroy (this.gameObject);
		//}	
	}
}
