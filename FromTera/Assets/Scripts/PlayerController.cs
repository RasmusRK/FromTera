using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float mainSpeed;
	public float sideSpeed;
	public float frontSpeed;
	public float rotationSpeed;
	private Rigidbody2D rb;
	// smid de her i sit eget objekt, se evt tutorial
	public GameObject thrust1;
	public GameObject thrust2;
	public GameObject thrust3;
	public GameObject thrust4;
	public GameObject thrust5;
	public KeyCode thrustBackLeftKey;
	public KeyCode thrustBackRightKey;
	public KeyCode thrustFrontLeftKey;
	public KeyCode thrustFrontRighKey;
	public KeyCode thrustFrontMainKey;

	public KeyCode thrustBackLeftKey_cont;
	public KeyCode thrustBackRightKey_cont;
	public KeyCode thrustFrontLeftKey_cont;
	public KeyCode thrustFrontRighKey_cont;
	public KeyCode thrustFrontMainKey_cont;

	public GameObject shot;
	public Transform shotSpawn;
	private float nextFire = 0.5F;
	public float fireDelta = 0.5F;
	private float myTime = 0.0F;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D>();
		thrust1.transform.Find("Thruster_temp").gameObject.SetActive(false);
		thrust2.transform.Find("Thruster_temp").gameObject.SetActive(false);
		thrust3.transform.Find("Thruster_temp").gameObject.SetActive(false);
		thrust4.transform.Find("Thruster_temp").gameObject.SetActive(false);
		thrust5.transform.Find("Thruster_temp").gameObject.SetActive(false);
	}
	
	void FixedUpdate () {
		Vector2 sideThrust = transform.right;
		//var main = thrust1.GetComponentsInChildren<ParticleSystem>()[0].main;
		//main.startRotation = thrust1.transform.rotation;


		// Movement
		if(Input.GetKey(thrustBackLeftKey)  || Input.GetKeyDown(thrustBackLeftKey_cont ))
		{
			rb.AddForceAtPosition (transform.forward* mainSpeed ,thrust1.transform.position);
			thrust1.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (thrustBackRightKey)||Input.GetKey(thrustBackRightKey_cont))
		{
			rb.AddForceAtPosition (transform.forward* mainSpeed , thrust2.transform.position);
			thrust2.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (thrustFrontLeftKey)||Input.GetKey(thrustFrontLeftKey_cont))
		{
			rb.AddForceAtPosition (sideThrust * sideSpeed , thrust3.transform.position);
			thrust3.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (thrustFrontRighKey)||Input.GetKey(thrustFrontRighKey_cont))
		{
			rb.AddForceAtPosition (sideThrust * -sideSpeed , thrust4.transform.position);
			thrust4.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (thrustFrontMainKey)||Input.GetKey(thrustFrontMainKey_cont))
		{
			rb.AddForceAtPosition (transform.forward * -frontSpeed, thrust5.transform.position);
			thrust5.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}

		// Fire
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && myTime > nextFire) {
			nextFire = myTime + fireDelta;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation,rb.transform);

			// create code here that animates the newProjectile        

			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}

		//transform.Rotate(0, rotation, 0);
	}
	void LateUpdate()
	{
		
		if (Input.GetKeyUp (thrustBackLeftKey) || Input.GetKeyUp (thrustBackLeftKey_cont))
		{
			thrust1.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (thrustBackRightKey) || Input.GetKeyUp (thrustBackRightKey_cont))
		{
			thrust2.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (thrustFrontLeftKey) || Input.GetKeyUp (thrustFrontLeftKey_cont))
		{
			thrust3.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (thrustFrontRighKey) || Input.GetKeyUp (thrustFrontRighKey_cont))
		{
			thrust4.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (thrustFrontMainKey) || Input.GetKeyUp (thrustFrontMainKey_cont))
		{
			thrust5.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}

	}
}
