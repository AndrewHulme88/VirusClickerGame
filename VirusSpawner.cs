using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [SerializeField] GameObject virusPrefab;
    [SerializeField] float spawnIntervalMin = 0.1f;
    [SerializeField] float spawnIntervalMax = 2f;
    [SerializeField] float spawnDistance = 15f;

    private Vector2 screenBounds;
    private float spawnInterval;

    void Start()
    {
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        StartCoroutine(SpawnViruses());
    }

    IEnumerator SpawnViruses()
    {
        while(true)
        {
            SpawnVirus();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnVirus()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 spawnPosition = new Vector2(Mathf.Cos(angle) * spawnDistance, Mathf.Sin(angle) * spawnDistance);

        Instantiate(virusPrefab, spawnPosition, Quaternion.identity);
    }
}
