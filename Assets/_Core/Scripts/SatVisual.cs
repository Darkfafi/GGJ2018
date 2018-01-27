using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatVisual : MonoBehaviour {

	public Transform target;

	public Transform satBase;

	public float lerpSpeed = 0.02f;

	public Transform explosionPrefab;

    public bool Killable = true;

    private float delayTrail = 0;
    private bool trailActive = false;

    protected void Update()
    {
        if (!trailActive)
        {
            delayTrail += Time.deltaTime; 
            if (delayTrail > 0.1f)
            {
                GetComponent<TrailRenderer>().Clear();
                GetComponent<TrailRenderer>().enabled = true;
                trailActive = true;
            }
        }
    }

	void OnTriggerStay(Collider coll)
	{
        TowerBase tb = coll.transform.GetComponent<TowerBase>();
		if (tb)
		{
            //	Debug.Log("switching orbit height");
            if (tb.mode != Modes.None)
            {
                satBase.GetComponent<SatelliteBase>().mode = tb.mode;
            }
		}

		if (coll.transform.GetComponent<SatVisual>())
		{
            if (Killable)
            {
                Health.singleton.DoDamage(.1f);
                KillSatellite(coll.transform);
            }

			/*
			foreach (Transform t in transform)
			{
				KillSatellite(t);
			}

			foreach (Transform t in coll.transform)
			{
				KillSatellite(t);
			}
			*/
		//	Destroy(coll.transform.gameObject);
		//	Destroy(gameObject);
		}
	}

	void KillSatellite(Transform t)
	{
		Transform explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as Transform;
		Destroy(t.parent.gameObject);
	}

}
