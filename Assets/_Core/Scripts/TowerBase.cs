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

	public enum Modes
	{
		HIGHER,
		LOWER,
		MEDIUM,
		HIT
	};

	public Modes mode = Modes.MEDIUM;

	public Transform emitter;

	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 1000, transmitterMask))
		{
			if (Input.GetMouseButtonDown(0))
			{
				

				if (mode == Modes.MEDIUM)
				{
                    HigherOrbit();
					Transform t = Instantiate(particleHigherOrbit, emitter.position, emitter.rotation);
				}
				else if (mode == Modes.LOWER)
				{
					MediumOrbit();
					Transform t = Instantiate(particleHigherOrbit, emitter.position, emitter.rotation);
				}
			}

			if (Input.GetMouseButtonDown(1))
			{
					

				if (mode == Modes.MEDIUM)
				{
					LowerOrbit();
					Transform t = Instantiate(particleLowerOrbit, emitter.position, emitter.rotation);

				}
				else if (mode == Modes.HIGHER)
				{
                    MediumOrbit();
					Transform t = Instantiate(particleLowerOrbit, emitter.position, emitter.rotation);
				}
			}
		}
	}

	void HigherOrbit()
	{
		Debug.Log("switching tower to high");
		mode = Modes.HIGHER;
		emitter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
	}

	void LowerOrbit()
	{
		Debug.Log("switching tower to low");
		mode = Modes.LOWER;
		emitter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
	}

	void MediumOrbit()
	{
		Debug.Log("switching tower to medium");
		mode = Modes.MEDIUM;
		emitter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
	}

	void OnMouseExit()
	{
		
	}

	void Start () {
		
	}
}
