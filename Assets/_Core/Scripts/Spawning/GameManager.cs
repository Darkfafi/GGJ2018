using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SataliteSpawner spawner;

    [SerializeField]
    private Transform center;

    // Spawning
    private float lastSpawnTime = 0;
    private float spawnDelay = 0;
    private int level;

    // Clearing outside ring
    private float outerRingTime = 0;
    private float outerRingDelay = 10;

    private float counter = 0;

    protected void Awake()
    {
        OuterRing();
    }

    protected void Update()
    {
        lastSpawnTime += Time.deltaTime;
        if(lastSpawnTime > spawnDelay)
        {
            SetNextLevel();
        }

        //

        outerRingTime += Time.deltaTime;
        if(outerRingTime > outerRingDelay)
        {
            OuterRing();
        }
    }

    private void OuterRing()
    {
        outerRingTime = 0;
        outerRingDelay = UnityEngine.Random.Range(8f, 16f);

        center.transform.DOShakeScale(4f, 0.2f).SetDelay(outerRingTime - 7f);
        center.transform.DOShakeScale(3f, 0.5f).OnComplete(() => {

            Vector3 os = center.localScale;

            center.transform.localScale = os * 0.8f;

            center.transform.DOScale(os, 2f).SetEase(Ease.OutElastic);

        }).SetDelay(outerRingDelay - 3f);
            

        SatelliteBase[] allSatilites = FindObjectsOfType<SatelliteBase>();
        

        for(int i = 0; i < allSatilites.Length; i++)
        {
            int cm = (int)allSatilites[i].mode;
            int l = Enum.GetValues(typeof(Modes)).Length;
            if(cm == l - 1)
            {
                ReleaseSatellite(allSatilites[i]);
            }
            else
            {
                allSatilites[i].mode = ((Modes)cm + 1);
            }
        }
    }

    private void ReleaseSatellite(SatelliteBase sat)
    {
        sat.SetReleased();
    }

    private void SetNextLevel()
    {
        level++;
        spawnDelay = 3 + UnityEngine.Random.Range(4 - (int)(level / 5), 6);
        lastSpawnTime = 0;
        StartCoroutine(SpawnAmount((int)(1 + level / 5)));
    }

    private IEnumerator SpawnAmount(int v)
    {
        for(int i = 0; i < v; i++)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.3f));
            spawner.SpawnSatelite();
        }
    }
}
