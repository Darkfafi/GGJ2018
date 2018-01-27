using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SataliteSpawner spawner;

    private float lastSpawnTime = 0;
    private float spawnDelay = 0;
    private int level;

    private float counter = 0;

    protected void Update()
    {
        lastSpawnTime += Time.deltaTime;
        if(lastSpawnTime > spawnDelay)
        {
            SetNextLevel();
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
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.3f));
            spawner.SpawnSatelite();
        }
    }
}
