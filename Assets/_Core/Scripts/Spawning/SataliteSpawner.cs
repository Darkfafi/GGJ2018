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

    public void SpawnSatelite(float rot)
    {
        SatelliteBase sb = Instantiate(satelitePrefab, transform.position, Quaternion.identity);
        sb.transform.position = Center.transform.position;
        sb.Visual.transform.position = transform.position;

        sb.transform.rotation = Quaternion.Euler(0, 0, rot); //  Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
        sb.mode = Modes.HEO;
        launcher.SendToPointInSpace(sb, sb.transform.up, Modes.HEO, 3.2f);
    }
}
