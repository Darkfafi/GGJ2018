using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public static Health singleton;

	float health = 1;

	void Awake()
	{
		if (singleton == null)
		{
			singleton = this;
		}
		else
		{
			Debug.LogError("singleton of health already exists");
		}

	}


	public void DoDamage(float amount)
	{
		health = health - amount;

		GetComponent<Image>().fillAmount = health;

	}

}
