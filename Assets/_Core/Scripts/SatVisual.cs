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

    private float newSignalCooldown = 2.5f;
    private float newSignalDelayCounter = 0;

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

        if (newSignalDelayCounter >= 0)
        {
            newSignalDelayCounter += Time.deltaTime;
            if (newSignalDelayCounter > newSignalCooldown)
            {
                newSignalDelayCounter = -1337;
            }
        }

		if (tb && newSignalDelayCounter < 0)
		{
            //	Debug.Log("switching orbit height");
            if (tb.mode != Modes.None && tb.mode != satBase.GetComponent<SatelliteBase>().mode)
            {
                int l = System.Enum.GetValues(typeof(Modes)).Length;
                int tbVal = (int)tb.mode;
                int currentVal = (int)satBase.GetComponent<SatelliteBase>().mode;
                if(tbVal < currentVal && currentVal > 1)
                {
                    satBase.GetComponent<SatelliteBase>().mode = (Modes)(currentVal - 1);
                    newSignalDelayCounter = 0;
                }
                else if(tbVal > currentVal && currentVal < l - 1)
                {
                    satBase.GetComponent<SatelliteBase>().mode = (Modes)(currentVal + 1);
                    newSignalDelayCounter = 0;
                }
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
