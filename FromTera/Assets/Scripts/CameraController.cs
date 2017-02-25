using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject[] players;
	private Vector3 offset;
	private Vector3 newpos;
	private float furthest;
	private Camera main_cam;

	void Start ()
	{
		foreach(GameObject player in players)
		{
			offset += player.transform.position;
		}
		offset = transform.position - offset/players.Length;
		furthest = 0;
		main_cam = GetComponent<Camera> ();
	}

	void Awake()
	{
		players = GameObject.FindGameObjectsWithTag("Player");
	}

	void LateUpdate ()
	{
		if (players.Length > 1) {
			MultiplayerCamera ();
		} else {
			SinglePlayerCamera ();
		}
	}

	private void SinglePlayerCamera()
	{
		transform.position = players[0].transform.position + offset;
	}

	private void MultiplayerCamera()
	{
		newpos = new Vector3(0,0,0);
		furthest = 0;
		foreach(GameObject player1 in players)
		{
			newpos += player1.transform.position;
			foreach (GameObject player2 in players) {
				if (player2 != player1 && furthest < (player1.transform.position - player2.transform.position).magnitude) {
					furthest = (player1.transform.position - player2.transform.position).magnitude;

				}
			}
		}
		print (furthest);
		main_cam.orthographicSize = Mathf.Max(furthest * (float) 0.6,7);
		transform.position = newpos/players.Length + offset;
	}
}
