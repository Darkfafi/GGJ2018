using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Screenshake : MonoBehaviour {

    public static Screenshake _instance;
    public static Screenshake Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Screenshake>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Screenshake");
                    _instance = container.AddComponent<Screenshake>();
                }
            }

            return _instance;
        }
    }

    public void Shake(float _strenght, float _duration)
    {
        Camera.main.transform.DOShakePosition(_duration, _strenght);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
