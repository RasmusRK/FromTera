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
		//float rot_y = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
		//float rot_x = Mathf.Atan2(diff.z, diff.y) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler(rot_x, rot_y, rot_z);
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90f);
		}
}
