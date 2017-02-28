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
	public GameObject thrustBackLeft;
	public GameObject thrustBackRight;
	public GameObject thrustFrontLeft;
	public GameObject thrustFrontRight;
	public GameObject thrustFrontMain;
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

	public GameObject shotType;
	public Transform shotSpawn;
	private float nextFire = 0.5F;
	public float fireDelta = 0.5F;
	private float myTime = 0.0F;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D>();
		thrustBackLeft.transform.Find("Thruster_temp").gameObject.SetActive(false);
		thrustBackRight.transform.Find("Thruster_temp").gameObject.SetActive(false);
		thrustFrontLeft.transform.Find("Thruster_temp").gameObject.SetActive(false);
		thrustFrontRight.transform.Find("Thruster_temp").gameObject.SetActive(false);
		thrustFrontMain.transform.Find("Thruster_temp").gameObject.SetActive(false);
	}
	
	void FixedUpdate () {
		Vector2 sideThrust = transform.right;
		//var main = thrust1.GetComponentsInChildren<ParticleSystem>()[0].main;
		//main.startRotation = thrust1.transform.rotation;


		// Movement
		if(Input.GetKey(thrustBackLeftKey)  || Input.GetKeyDown(thrustBackLeftKey_cont ))
		{
			rb.AddForceAtPosition (transform.forward* mainSpeed ,thrustBackLeft.transform.position);
			thrustBackLeft.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (thrustBackRightKey)||Input.GetKey(thrustBackRightKey_cont))
		{
			rb.AddForceAtPosition (transform.forward* mainSpeed , thrustBackRight.transform.position);
			thrustBackRight.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (thrustFrontLeftKey)||Input.GetKey(thrustFrontLeftKey_cont))
		{
			rb.AddForceAtPosition (transform.right* sideSpeed , thrustFrontLeft.transform.position);
			thrustFrontLeft.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (thrustFrontRighKey)||Input.GetKey(thrustFrontRighKey_cont))
		{
			rb.AddForceAtPosition (transform.right * -sideSpeed , thrustFrontRight.transform.position);
			thrustFrontRight.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (thrustFrontMainKey)||Input.GetKey(thrustFrontMainKey_cont))
		{
			rb.AddForceAtPosition (transform.forward * -frontSpeed, thrustFrontMain.transform.position);
			thrustFrontMain.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}

		// Fire
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && myTime > nextFire) {
			nextFire = myTime + fireDelta;
			GameObject shot = Instantiate(shotType, shotSpawn.position, shotSpawn.rotation,rb.transform);
			shot.GetComponent<Rigidbody2D> ().AddForce (transform.forward * 50);
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
			thrustBackLeft.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (thrustBackRightKey) || Input.GetKeyUp (thrustBackRightKey_cont))
		{
			thrustBackRight.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (thrustFrontLeftKey) || Input.GetKeyUp (thrustFrontLeftKey_cont))
		{
			thrustFrontLeft.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (thrustFrontRighKey) || Input.GetKeyUp (thrustFrontRighKey_cont))
		{
			thrustFrontRight.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (thrustFrontMainKey) || Input.GetKeyUp (thrustFrontMainKey_cont))
		{
			thrustFrontMain.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}

	}
}
