using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    [Header("Wave Settings")]
    [SerializeField] private float timeBetweenWaves;
    private float waveTimer;

    [SerializeField] private WaveDefinition[] waves;
    //[SerializeField] private Wave[] waves;
    private int waveIndex;

    [HideInInspector]
    public bool needToSpawnWave;

    private int enemiesSpawnedAmount;

    [SerializeField] private Transform[] spawnPos;

    public float timeSpeed = 1;

    private void Awake()
    {
        instance = this;
        needToSpawnWave = true;
        waveTimer = timeBetweenWaves;
    }

    private void Update()
    {
        if (!needToSpawnWave) return;

        waveTimer -= Time.deltaTime;

        UiManager.instance.SetWaveTimer((int)waveTimer);


        if (waveTimer <= 0 && needToSpawnWave)
        {
            needToSpawnWave = false;
            enemiesSpawnedAmount = 0;
            waveTimer = timeBetweenWaves;

            if (waveIndex > waves.Length - 1)
            {
                GameManager.Instance.OnLevelCompletion();
            }
            else
            {
                needToSpawnWave = false;
                StartCoroutine(Spawn());
            }
        }

        
    }

    IEnumerator Spawn()
    {
        float generalTimer = 0;
        enemiesSpawnedAmount = waves[waveIndex].enemies.Length;
        GameManager.Instance.SetEnemiesAmount(enemiesSpawnedAmount);

        float roundTimer = 0;
        foreach(WaveDefinition.EnemyInfo enemies in waves[waveIndex].enemies)
        {
            roundTimer += enemies.spawnDelay;
            generalTimer += enemies.spawnDelay;
        }
        UiManager.instance.SetRoundSliderInitialValue(roundTimer);

        float maximumTimer = generalTimer;

        List<GameObject> spawnedEnemies = new List<GameObject>();
        List<float> spawnDelay = new List<float>();

        foreach (WaveDefinition.EnemyInfo enemy in waves[waveIndex].enemies)
        {
            generalTimer -= enemy.spawnDelay;
            float timerFraction = generalTimer / maximumTimer; // assuming generalTimer ranges from 0 to 180
            Vector3 positionOffset = Vector3.right * 30f * (1 - timerFraction); // Adjusted position based on generalTimer

            GameObject spawnedEnemy = Instantiate(enemy.enemyPrefab, spawnPos[Random.Range(0, spawnPos.Length)].transform.position + positionOffset, enemy.enemyPrefab.transform.rotation); spawnedEnemy.transform.GetChild(0).GetComponent<Enemy>().enabled = false;
            spawnedEnemies.Add(spawnedEnemy);
            spawnDelay.Add(enemy.spawnDelay);
        }

        int i = 0;

        generalTimer = 0;
        foreach (GameObject enemy in spawnedEnemies)
        {
            generalTimer += spawnDelay[i];
            StartCoroutine(MoveEnemyToInitialPosition(enemy.transform, generalTimer));
            i++;
        }
        yield return null;
        waveIndex++;
    }

    IEnumerator MoveEnemyToInitialPosition(Transform enemyTransform, float delay)
    {
        float timer = 0f;
        Vector3 neededPosition = new Vector3(spawnPos[0].position.x, enemyTransform.position.y, enemyTransform.position.z);
        enemyTransform.LookAt(neededPosition);
        Vector3 startPosition = enemyTransform.position;
        float distanceToMove = Vector3.Distance(startPosition, neededPosition);

        while (timer < delay * timeSpeed)
        {
            timer += Time.deltaTime;
            float maxDistanceDelta = (distanceToMove / (delay * timeSpeed)) * Time.deltaTime;
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, neededPosition, maxDistanceDelta);
            yield return null;
        }

        enemyTransform.position = neededPosition; // Ensure enemy reaches its initial position precisely
        enemyTransform.GetChild(0).GetComponent<Enemy>().enabled = true;
    }
}
