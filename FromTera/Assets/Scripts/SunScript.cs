using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunScript : MonoBehaviour {

	private float distr;
	private double G = 6.6733e-9;
	private float  vel;
	private float vel1;
	private Rigidbody2D rb;
	private float sunmass;
	private float Gmm;
	private float mass;
	private float dt = (float)1e5;
	//private double vx;
	//private double vy;
	private float m;
	private float x;
	private float y;
	int count = 0;
	private List<float> vx = new List<float>();
	private List <float>vy= new List<float>();
	int afflen;

	public GameObject[] affected;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		affected = GameObject.FindGameObjectsWithTag ("Asteroid");
		afflen = affected.Length;
		foreach(GameObject aff in affected)
		{
			aff.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200.0f,0));
			vx.Add(0.0f);
			vy.Add(0.0f);
		}



	}
	
	// Update is called once per frame
	void FixedUpdate () {
		count = 0;
		foreach (GameObject aff in affected) 
		{
			m = aff.GetComponent<Rigidbody2D> ().mass;
			x = aff.transform.position.x;
			y = aff.transform.position.y;
			distr = Mathf.Sqrt(Mathf.Pow (this.transform.position.x - x, 2)+Mathf.Pow(this.transform.position.y - y,2));
			Gmm = (float)G * rb.mass * m;

			vel = (Gmm * ((this.transform.position.x-x)/distr)/rb.mass * dt);
			vel1 = (Gmm * ((this.transform.position.y-y)/distr)/rb.mass * dt);

			vx[count%afflen] += vel;
			vy[count%afflen] += vel1;
			print (vx [count % afflen]);
			aff.GetComponent<Rigidbody2D>().AddForce(new Vector3 (vx[count%afflen]*10 ,vy[count%afflen]*10,0));
			count++;

		}

	}
}
