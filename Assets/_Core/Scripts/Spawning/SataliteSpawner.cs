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
        SatelliteBase sb = Instantiate(satelitePrefab, transform.position, Quaternion.identity);
        sb.transform.position = Center.transform.position;
        sb.Visual.transform.position = transform.position;

        int rl = UnityEngine.Random.Range(1, 4);

        sb.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
        sb.mode = (Modes)rl;
        launcher.SendToPointInSpace(sb, sb.transform.up, (Modes)rl, 3.2f);
    }
}
