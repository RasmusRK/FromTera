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
		if (!(this.tag == "Rocket")) 
		{
			Destroy (this.gameObject);
		}	

		if (coll.transform.tag == "Asteroid") 
		{
			//coll.transform.GetComponent<Rigidbody2D> ().AddForce (this.transform.position * 100);
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
			this.transform.position = coll.transform.position;
		}
			
	}
}
