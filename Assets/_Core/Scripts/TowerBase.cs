using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
	Ray ray;

	RaycastHit hit;

	public LayerMask transmitterMask;
	public LayerMask transmitterRangeMask;

	public Transform particleHigherOrbit;
	public Transform particleLowerOrbit;

    [SerializeField]
    private GameObject towerModelInstance;

	public Modes mode = Modes.MEO;

	public Transform emitter;

	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 1000, transmitterMask);

        if (hit.collider != null && hit.collider.gameObject == towerModelInstance)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (mode == Modes.MEO || mode == Modes.None)
				{
                    HigherOrbit();
                    DoParticle(particleHigherOrbit);
				}
				else if (mode == Modes.LEO)
				{
					MediumOrbit();
                    DoParticle(particleHigherOrbit);
                }
			}

			if (Input.GetMouseButtonDown(1))
			{
                if (mode == Modes.MEO || mode == Modes.None)
				{
					LowerOrbit();
                    DoParticle(particleLowerOrbit);

				}
				else if (mode == Modes.HEO)
				{
                    MediumOrbit();
                    DoParticle(particleLowerOrbit);
                }
			}
		}
	}


    private void DoParticle(Transform particlePrefab)
    {
        Transform t = Instantiate(particlePrefab, emitter.transform);
        t.transform.localPosition = Vector3.zero;
    }

	void HigherOrbit()
	{
		Debug.Log("switching tower to high");
        mode = Modes.HEO;
//		emitter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
	}

	void LowerOrbit()
	{
		Debug.Log("switching tower to low");
		mode = Modes.LEO;
//		emitter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
	}

	void MediumOrbit()
	{
		Debug.Log("switching tower to medium");
		mode = Modes.MEO;
//		emitter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
	}

	void OnMouseExit()
	{
		
	}

	void Start () {
		
	}
}
