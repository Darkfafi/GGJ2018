using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatBase : MonoBehaviour {

	public Vector3 orbitRotation;

	void Start () {
		
	}

	void FixedUpdate () {

		transform.Rotate(orbitRotation);
	}
}
