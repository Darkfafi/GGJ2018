using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public float killtime = 3;

	void Start () {
		Destroy(gameObject, killtime);
	}

}
