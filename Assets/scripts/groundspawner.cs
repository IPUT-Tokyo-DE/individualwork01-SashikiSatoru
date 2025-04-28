using System.Collections.Generic;
using UnityEngine;

public class groundspawner : MonoBehaviour
{
    public GameObject groundPrefab; // 地面プレハブ
    public float spawnInterval = 2f; // 生成間隔
    public float moveSpeed = 2f;     // 左に流れるスピード
    public float groundLifetime = 10f; // 削除時間

    public int minHeight = 1;
    public int maxHeight = 4;
    public int platformsPerSpawn = 2; // 一度に出す段数

    private float timer;

    public GameObject circleCoinPrefab;
    public GameObject triangleCoinPrefab;
    public GameObject squareCoinPrefab;
    [Range(0f, 1f)]
    public float coinSpawnChance = 0.8f; // 80%


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnGrounds();
        }
    }

    void SpawnGrounds()
    {
        List<int> possibleHeights = new List<int> { 1, 1,  2, 2, 3, 4 };
        List<int> chosenHeights = new List<int>();

        for (int i = 0; i < platformsPerSpawn; i++)
        {
            if (possibleHeights.Count == 0) break;
            int index = Random.Range(0, possibleHeights.Count);
            chosenHeights.Add(possibleHeights[index]);
            possibleHeights.RemoveAt(index);
        }

        foreach (int height in chosenHeights)
        {
            Vector3 spawnPos = new Vector3(10f, height * 2.5f, 0);
            GameObject ground = Instantiate(groundPrefab, spawnPos, Quaternion.identity);
            ground.transform.localScale = new Vector3(Random.Range(4f, 7f), 0.1f, 0f);

            ground.AddComponent<moveleft>().speed = moveSpeed;
            Destroy(ground, groundLifetime);

            // 80%の確率でコイン生成
            float groundWidth = ground.transform.localScale.x;

            if (Random.value < coinSpawnChance)
            {
                SpawnRandomCoinAbove(ground.transform.position, groundWidth);
            }

        }
    }
    void SpawnRandomCoinAbove(Vector3 groundPosition, float groundWidth)
    {

        int maxCoins = Mathf.FloorToInt(groundWidth / 1.5f);
        if (maxCoins < 1) maxCoins = 1;

        float spacing = groundWidth / maxCoins;
        float startX = groundPosition.x - groundWidth / 2 + spacing / 2;
        float y = groundPosition.y + 0.5f;

        for (int i = 0; i < maxCoins; i++)
        {
            if (Random.value < 0.5f)
            {
                GameObject coinPrefab = GetRandomCoinPrefab();
                Vector3 coinPos = new Vector3(startX + i * spacing, y, 0);
                GameObject coin = Instantiate(coinPrefab, coinPos, Quaternion.identity);
                coin.transform.localScale = Vector3.one * 0.5f; 
                coin.AddComponent<moveleft>().speed = moveSpeed;
                Destroy(coin, groundLifetime);
            }
        }

        GameObject GetRandomCoinPrefab()
        {
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0: return circleCoinPrefab;
                case 1: return triangleCoinPrefab;
                case 2: return squareCoinPrefab;
                default: return circleCoinPrefab; // fallback
            }
        }
    }

}
