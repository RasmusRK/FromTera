using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToPlayer : MonoBehaviour {

	private GameObject player;
	void Start () {
		player =  GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		Vector3 diff = this.transform.position - player.transform.position;
		diff.Normalize ();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}
}
