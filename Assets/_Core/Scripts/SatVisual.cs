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

		if (coll.transform.GetComponent<SatVisual>())
		{
			foreach (Transform t in transform)
			{
				KillSatellite(t);
			}

			foreach (Transform t in coll.transform)
			{
				KillSatellite(t);
			}

		//	Destroy(coll.transform.gameObject);
		//	Destroy(gameObject);
		}
	}

	void KillSatellite(Transform t)
	{

		if (t.tag == "panel")
		{
			Destroy(t.gameObject);
		}
		else
		{			
			t.gameObject.AddComponent<SphereCollider>();
			t.gameObject.AddComponent<Rigidbody>();
			t.gameObject.GetComponent<TrailRenderer>().time = 1;
		//	Destroy(t.gameObject, 5);
			//t.parent = null;
        //    Destroy(t.parent.gameObject, 2);
		}
	}

}
