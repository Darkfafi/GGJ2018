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
    private Vector3 oldScale;
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
        oldScale = center.transform.localScale;
        //OuterRing();

        AudioSystem.Instance.StopAudio();
        AudioSystem.Instance.PlaySoloAudio("OST", AudioSystem.MUSIC_STATION);
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

        if(tweenSequence != null && tweenSequence.IsPlaying())
        {
            tweenSequence.Complete(true);
        }

        tweenSequence = DOTween.Sequence();
        tweenSequence.AppendInterval(outerRingDelay - 3f);
        tweenSequence.Append(center.transform.DOScale(oldScale * 0.5f, 2f).SetEase(Ease.InCirc).OnStart(() => { AudioSystem.Instance.PlayAudio("ReadyToBlow"); }).OnComplete(() => { 
            WaarIsSimon(); 
            AudioSystem.Instance.PlayAudio("BlowPlanet");
        }));
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
        int spawnAmount = 1;

        switch (GetSection(level))
        {
            case 0:
                spawnDelay = 10;
                spawnAmount = 1;
                outerRingDelay = 10;
                break;
            case 1:
                spawnDelay = 10;
                spawnAmount = UnityEngine.Random.Range(2, 4);
                outerRingDelay = UnityEngine.Random.Range(10, 16);
                break;
            case 2:
                spawnDelay = 10;
                spawnAmount = UnityEngine.Random.Range(3, 5);
                outerRingDelay = UnityEngine.Random.Range(11, 16);
                break;
            default:
                spawnDelay = 8;
                spawnAmount = UnityEngine.Random.Range(4, 6);
                outerRingDelay = UnityEngine.Random.Range(11, 16);
                break;
        }

        lastSpawnTime = 0;
        StartCoroutine(SpawnAmount(spawnAmount));
    }

    private IEnumerator SpawnAmount(int v)
    {
        Camera.main.DOFieldOfView(85, 2f).SetEase(Ease.OutQuad).OnComplete(
            ()=> {

                Camera.main.DOFieldOfView(65, 1.5f).SetEase(Ease.InOutQuad).SetDelay(0.5f);
            });

        float angle = (360f / (float)v) + UnityEngine.Random.Range(0, 360);
        float tv = (v < 2) ? 0.7f : 0;

        for (int i = 0; i < v; i++)
        {
            spawner.SpawnSatelite(angle * (i + 1));
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f + tv, 0.8f + tv));

        }
    }

    private int GetSection(int level)
    {
        if (level <= 2)
            return 0;
        if (level <= 6)
            return 1;
        if (level <= 10)
            return 2;

        return -1;
    }
}
