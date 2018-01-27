using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
	Ray ray;

	RaycastHit hit;

	public LayerMask transmitterMask;
	public LayerMask transmitterRangeMask;

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
				}
				else if (mode == Modes.LOWER)
				{
					MediumOrbit();
				}
			}

			if (Input.GetMouseButtonDown(1))
			{
					

				if (mode == Modes.MEDIUM)
				{
					LowerOrbit();
				}
				else if (mode == Modes.HIGHER)
				{
                    MediumOrbit();
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
