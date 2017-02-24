using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject[] players;
	private Vector3 offset;
	private Vector3 newpos;

	void Start ()
	{
		foreach(GameObject player in players)
		{
			offset += player.transform.position;
		}
		offset = transform.position - offset/players.Length;
	}

	void Awake()
	{
		players = GameObject.FindGameObjectsWithTag("Player");
	}

	void LateUpdate ()
	{
		newpos = new Vector3(0,0,0);
		foreach(GameObject player in players)
		{
			newpos += player.transform.position;
		}
		transform.position = newpos/players.Length + offset;
	}
}
