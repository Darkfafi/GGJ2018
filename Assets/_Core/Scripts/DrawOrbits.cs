using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOrbits : MonoBehaviour {


	void Update () {

		DrawLine.Instance.DrawSimpleLine(new Vector3(-100, 0, 0), new Vector3(100, 0, 0), Color.red);

		DrawLine.Instance.DrawCircle(50, Vector3.zero, 30, Color.red);

	}
}
