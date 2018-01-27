using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatVisual : MonoBehaviour {

	public Transform target;


	void FixedUpdate () {
		transform.position = Vector3.Lerp(transform.position, target.position, .2f);
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, .2f);
	}
}
