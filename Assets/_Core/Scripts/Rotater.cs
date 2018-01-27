using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

	public Vector3 rot;

	void FixedUpdate () {
		transform.Rotate(rot);
	}
}
