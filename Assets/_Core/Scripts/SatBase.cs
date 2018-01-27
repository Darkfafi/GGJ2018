using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatBase : MonoBehaviour {

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

	void Start () {
		
	}

	void FixedUpdate () {

		transform.Rotate(orbitRotation);

		switch (mode)
		{

			case Modes.LEO:

				visual.position = Vector3.Lerp(visual.position, leo.position, lerpSpeed);
				visual.rotation = Quaternion.Lerp(visual.rotation, leo.rotation, lerpSpeed);
				break;

			case Modes.MEO:
				visual.position = Vector3.Lerp(visual.position, meo.position, lerpSpeed);
				visual.rotation = Quaternion.Lerp(visual.rotation, meo.rotation, lerpSpeed);


				break;

			case Modes.HEO:

					visual.position = Vector3.Lerp(visual.position, heo.position, lerpSpeed);
				visual.rotation = Quaternion.Lerp(visual.rotation, heo.rotation, lerpSpeed);

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
