using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	// Use this for initialization
	void Start ()
	{
		//rb = GetComponent<Rigidbody2D> ();

		//rb.AddForce (transform.parent.forward * speed);
		//rb.velocity = transform.parent.forward* speed;
		if (this.transform.tag == "Rocket") 
		{
			this.transform.Find("exhaust").gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)  
	{
		if (coll.gameObject.tag == "Shot")
			return;

		if (coll.transform.tag == "Wall") 
		{
			Destroy (this.gameObject);
		}	

		if (coll.transform.tag == "Asteroid") 
		{
			//coll.transform.GetComponent<Rigidbody2D> ().AddForce (this.transform.position * 100);
			//rb.constraints = RigidbodyConstraints2D.FreezeAll;
			print ("Asteroid hit");
			Destroy (this.GetComponent<Rigidbody2D> ());
			this.transform.parent = coll.transform;
			StartCoroutine(AccOnHit());

			//this.transform.position = coll.transform.position;
		}
			
	}
	IEnumerator AccOnHit()
	{
		yield return new WaitForSecondsRealtime(1.5f);
		float timestart= Time.time;
		float timeend = Time.time;
		this.transform.Find("exhaust").gameObject.SetActive(true);

		while (timeend - timestart <2.0f) 
		{
			yield return new WaitForSecondsRealtime(0.05f);
			this.transform.parent.GetComponent<Rigidbody2D> ().AddForce ((this.transform.parent.position-this.transform.position)*15);
			timeend = Time.time;
		}
		this.transform.Find("exhaust").gameObject.SetActive(false);
		Destroy (this.gameObject);

	}
}
