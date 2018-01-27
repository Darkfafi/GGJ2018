using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteSpawner : MonoBehaviour {

	public List<float> satelliteWave = new List<float>();

	int waveCount = 0;

	public Transform rocketPrefab;

	public List<Transform> rocketFacility = new List<Transform>();

	// Use this for initialization
	void Start () {
        StartCoroutine(WaveSpawner());
	}


	IEnumerator WaveSpawner()
	{
		yield return new WaitForSeconds(satelliteWave[waveCount]);

		if (waveCount < satelliteWave.Count)
		{

			Transform facility = rocketFacility[Random.Range(0, rocketFacility.Count)];

			Instantiate(rocketPrefab, facility.position, facility.rotation);

			waveCount++;

			StartCoroutine(WaveSpawner());

		}
	}


}
