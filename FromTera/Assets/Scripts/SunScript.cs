using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunScript : MonoBehaviour {

	private float distr;
	private double G = 6.6733e-10;
	private double vel;
	private Rigidbody2D rb;
	private double sunmass;
	private double Gmm;
	private float mass;
	private double dt = 1e5;
	private double vx;
	private double vy;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		foreach(Transform child in transform)
		{
			child.GetComponent<Rigidbody2D>().AddForce(new Vector2(-150.0f,30.0f));
		}

	}
	
	// Update is called once per frame
	void Update () {
		distr = Mathf.Sqrt(Mathf.Pow (this.transform.position.x - this.transform.GetChild (0).position.x, 2)+Mathf.Pow(this.transform.position.x - this.transform.GetChild(0).position.y,2));
		Gmm = G * rb.mass * transform.GetChild(0).GetComponent<Rigidbody2D>().mass;

		vel = (Gmm * ((this.transform.position.x - this.transform.GetChild (0).position.x)/distr)/rb.mass * dt);
		vx += vel;

		vel = (Gmm * ((this.transform.position.y - this.transform.GetChild (0).position.y)/distr)/rb.mass * dt);
		vy += vel;

		
		transform.GetChild (0).position += new Vector3 ((float) vx,(float) vy,0);

	}
}
