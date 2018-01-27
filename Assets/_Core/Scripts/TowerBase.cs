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

	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 100, transmitterMask))
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
	}

	void LowerOrbit()
	{
		Debug.Log("switching tower to low");
		mode = Modes.LOWER;
	}

	void MediumOrbit()
	{
		Debug.Log("switching tower to medium");
		mode = Modes.MEDIUM;
	}


	void OnMouseExit()
	{
		
	}

	void Start () {
		
	}

}
