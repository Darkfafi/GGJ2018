using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatVisual : MonoBehaviour {

	public Transform target;

	public Transform satBase;

	public float lerpSpeed = 0.02f;

	void FixedUpdate () {
		transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed);
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, lerpSpeed);
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.transform.GetComponent<TowerBase>())
		{			
		//	Debug.Log("switching orbit height");
			switch (coll.transform.GetComponent<TowerBase>().mode)
			{				
				case TowerBase.Modes.HIGHER:
					satBase.GetComponent<SatelliteBase>().mode = SatelliteBase.Modes.HEO;
					break;

				case TowerBase.Modes.MEDIUM:
					satBase.GetComponent<SatelliteBase>().mode = SatelliteBase.Modes.MEO;
					break;

				case TowerBase.Modes.LOWER:
					satBase.GetComponent<SatelliteBase>().mode = SatelliteBase.Modes.LEO;
					break;

			}
		}
	}
}
