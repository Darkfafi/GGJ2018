﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Score.Instance.AddScore(100f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Score.Instance.AddScore(-100f);
        }

	}
}
