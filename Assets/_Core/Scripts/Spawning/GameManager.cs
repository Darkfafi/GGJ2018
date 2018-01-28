﻿using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SataliteSpawner spawner;

    [SerializeField]
    private Transform center;

    [SerializeField]
    private Transform gameOverScreen;

    // Spawning
    private float lastSpawnTime = 0;
    private float spawnDelay = 0;
    private int level;

    // Clearing outside ring
    private float outerRingTime = 0;
    private float outerRingDelay = 10;

    private float counter = 0;

    private bool gameEnded = false;

    private Sequence tweenSequence;

    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("GameWithMenu");
    }

    protected void Awake()
    {
        //OuterRing();
    }

    protected void Update()
    {
        if (gameEnded) { return; }
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

    public void EndGame()
    {
        gameOverScreen.gameObject.SetActive(true);
        tweenSequence.Kill();
        StopAllCoroutines(); // Stops spawning enemies
        lastSpawnTime = 0;
        outerRingTime = 0;
        gameEnded = true;
        WaarIsSimon();

        SatelliteBase[] allSatellites = FindObjectsOfType<SatelliteBase>();

        for(int i = allSatellites.Length -1; i >= 0; i--)
        {
            SatelliteBase sb = allSatellites[i];
            if(sb.State == SatelliteBase.States.IN_ORBIT)
            {
                sb.Visual.GetComponent<SatVisual>().KillSatellite(sb.Visual);
            }
        }
    }

    private void OuterRing()
    {
        outerRingTime = 0;
        outerRingDelay = UnityEngine.Random.Range(8f, 16f);
        Vector3 oldScale = center.transform.localScale;

        tweenSequence = DOTween.Sequence();
        tweenSequence.AppendInterval(outerRingDelay - 3f);
        tweenSequence.Append(center.transform.DOScale(oldScale * 0.5f, 2f).SetEase(Ease.InCirc).OnComplete(() => { WaarIsSimon(); }));
        tweenSequence.Append(center.transform.DOScale(oldScale, 1f).SetEase(Ease.OutElastic));
        //tweenSequence.Join(center.transform.DOScale(oldScale, 1f).SetEase(Ease.OutElastic));
        tweenSequence.Play();
        /*center.transform.DOShakeScale(4f, 0.2f).SetDelay(outerRingTime - 7f);
        center.transform.DOShakeScale(3f, 0.5f).OnComplete(() => {

            Vector3 os = center.localScale;

            center.transform.localScale = os * 0.8f;

            center.transform.DOScale(os, 2f).SetEase(Ease.OutElastic);

        }).SetDelay(outerRingDelay - 3f);*/
    }

    private void WaarIsSimon()
    {
        print("waar is simon");
        Screenshake.Instance.Shake(1f, 1f);
        SatelliteBase[] allSatilites = FindObjectsOfType<SatelliteBase>();


        for (int i = 0; i < allSatilites.Length; i++)
        {
            int cm = (int)allSatilites[i].mode;
            int l = Enum.GetValues(typeof(Modes)).Length;
            if (cm == l - 1)
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
        if (sat.State == SatelliteBase.States.IN_ORBIT)
        {
            sat.SetReleased();
            Score.Instance.AddScore(100, sat.Visual.gameObject.transform.position);
        }
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
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 0.8f));
            spawner.SpawnSatelite();
        }
    }
}
