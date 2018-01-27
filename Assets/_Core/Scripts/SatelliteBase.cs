using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteBase : MonoBehaviour {

	public Transform visual;

	public Vector3 orbitRotation;

	public Transform leo;
	public Transform meo;
	public Transform heo;

	public float lerpSpeed = .2f;

	public enum Modes
	{
		LEO,
		MEO,
		HEO,
		DESTROYED,
		LAUNCHED
	};

	public Modes mode;

	void FixedUpdate () {

		transform.Rotate(orbitRotation);

		switch (mode)
		{

			case Modes.LEO:
				visual.position = Vector3.Lerp(visual.position, leo.position, lerpSpeed);
				visual.rotation = Quaternion.Lerp(visual.rotation, leo.rotation, lerpSpeed);
			//	Debug.Log("switch orbit to low");
				break;

			case Modes.MEO:
				visual.position = Vector3.Lerp(visual.position, meo.position, lerpSpeed);
				visual.rotation = Quaternion.Lerp(visual.rotation, meo.rotation, lerpSpeed);
			//	Debug.Log("switch orbit to medium");
				break;

			case Modes.HEO:
				visual.position = Vector3.Lerp(visual.position, heo.position, lerpSpeed);
				visual.rotation = Quaternion.Lerp(visual.rotation, heo.rotation, lerpSpeed);
			//	Debug.Log("switch orbit to high");
				break;

			case Modes.LAUNCHED:

				break;

			case Modes.DESTROYED:

				break;

			default:

				break;

		}
	}
}
