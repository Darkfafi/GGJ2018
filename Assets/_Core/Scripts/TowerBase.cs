using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{

	public enum Modes
	{
		HIGHER,
		LOWER,
		MEDIUM,
		HIT
	};

	public Modes mode = Modes.MEDIUM;

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (mode == Modes.LOWER)
			{
				MediumOrbit();
			}

			if (mode == Modes.MEDIUM)
			{
				HigherOrbit();
			}
		}

		if (Input.GetMouseButtonDown(1))
		{
			if (mode == Modes.HIGHER)
			{
                MediumOrbit();
			}

			if (mode == Modes.MEDIUM)
			{
				LowerOrbit();
			}
		}
	}

	void HigherOrbit()
	{
		mode = Modes.HIGHER;
	}

	void LowerOrbit()
	{
		mode = Modes.LOWER;
	}

	void MediumOrbit()
	{
		mode = Modes.MEDIUM;
	}


	void OnMouseExit()
	{
		
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
