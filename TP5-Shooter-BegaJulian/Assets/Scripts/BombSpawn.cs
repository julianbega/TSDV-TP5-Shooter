using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public float SpawnRatioTime;
    float TimeToNextBomb;

    public GameObject BombPrefab;
    public GameManager manager;
    public Terrain myTerrain;
    void LateStart()
    {
        myTerrain = FindObjectOfType<Terrain>();
        TimeToNextBomb = SpawnRatioTime;
    }
    void Update()
    {
        if (myTerrain == null)
        {
            myTerrain = FindObjectOfType<Terrain>();
        }
        TimeToNextBomb -= Time.deltaTime;

        if (TimeToNextBomb <= 0)
        {
            TimeToNextBomb = SpawnRatioTime;
            Instantiate(BombPrefab, SpawnBomb(), Quaternion.identity);
        }
    }

    Vector3 SpawnBomb()
    {
        Vector3 SpawnPoint = new Vector3(0, 0, 0);
        SpawnPoint.x = Random.Range(manager.MinXSpawnPosition, manager.MaxXSpawnPosition);
        SpawnPoint.z = Random.Range(manager.MinZSpawnPosition, manager.MaxZSpawnPosition);

        SpawnPoint.y = myTerrain.SampleHeight(SpawnPoint);
        return SpawnPoint;
    }
}
