﻿using System.Collections;
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

		if(Input.GetKey(KeyCode.W))
		{
			rb.AddForceAtPosition (transform.forward* mainSpeed ,thrust1.transform.position);
			thrust1.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (KeyCode.E))
		{
			rb.AddForceAtPosition (transform.forward* mainSpeed , thrust2.transform.position);
			thrust2.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (KeyCode.Q))
		{
			rb.AddForceAtPosition (sideThrust * sideSpeed , thrust3.transform.position);
			thrust3.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (KeyCode.R))
		{
			rb.AddForceAtPosition (sideThrust * -sideSpeed , thrust4.transform.position);
			thrust4.transform.Find("Thruster_temp").gameObject.SetActive(true);
		}
		if (Input.GetKey (KeyCode.S))
		{
			rb.AddForceAtPosition (transform.forward * -frontSpeed, thrust5.transform.position);
			thrust5.transform.Find("Thruster_temp").gameObject.SetActive(true);

		}

		//transform.Rotate(0, rotation, 0);
	}
	void LateUpdate()
	{
		
		if (Input.GetKeyUp (KeyCode.W))
		{
			thrust1.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (KeyCode.E))
		{
			thrust2.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (KeyCode.Q))
		{
			thrust3.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (KeyCode.R))
		{
			thrust4.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}
		if (Input.GetKeyUp (KeyCode.S))
		{
			thrust5.transform.Find("Thruster_temp").gameObject.SetActive(false);			
		}

	}
}