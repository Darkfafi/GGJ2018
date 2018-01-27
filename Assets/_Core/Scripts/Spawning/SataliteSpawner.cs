using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SataliteSpawner : MonoBehaviour
{
    [SerializeField]
    private SatelliteBase satelitePrefab;

    [SerializeField]
    private SpaceLaunch launcher;

    [SerializeField]
    private Transform Center;

    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnSatelite();
        }
    }

    private void SpawnSatelite()
    {
        SatelliteBase sb = Instantiate(satelitePrefab, transform.position, transform.rotation);
        sb.Visual.transform.position = transform.position;

        Vector3 randomAngleVec = new Vector3(UnityEngine.Random.Range(-5, 5), 5, UnityEngine.Random.Range(-5, 5));

        launcher.SendToPointInSpace(sb, randomAngleVec, Modes.MEO, 3);
    }
}
