using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatVisual : MonoBehaviour {

	public Transform target;

	public Transform satBase;


	void FixedUpdate () {
		transform.position = Vector3.Lerp(transform.position, target.position, .2f);
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, .2f);
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.transform.GetComponent<TowerBase>())
		{
			switch (coll.transform.GetComponent<TowerBase>().mode)
			{
				case TowerBase.Modes.HIGHER:
					satBase.GetComponent<SatBase>().mode = SatBase.Modes.HEO;
					break;

				case TowerBase.Modes.MEDIUM:
					satBase.GetComponent<SatBase>().mode = SatBase.Modes.MEO;
					break;

				case TowerBase.Modes.LOWER:
					satBase.GetComponent<SatBase>().mode = SatBase.Modes.LEO;
					break;

			}

		}
	}
}
