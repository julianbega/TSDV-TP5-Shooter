using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public float SpawnRatioTime;
    float TimeToNextGhost;

    public GameObject GhostPrefab;
    public GameManager manager;
    Terrain myTerrain;
    void Start()
    {
        myTerrain = FindObjectOfType<Terrain>();
        manager = GetComponent<GameManager>();
        TimeToNextGhost = SpawnRatioTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextGhost -= Time.deltaTime;

        if (TimeToNextGhost <= 0)
        {
            TimeToNextGhost = SpawnRatioTime;
            Instantiate(GhostPrefab, SpawnGhost(), Quaternion.identity);

        }


    }
    Vector3 SpawnGhost()
    {
        Vector3 SpawnPoint = new Vector3(0, 0, 0);
        SpawnPoint.x = Random.Range(manager.MinXSpawnPosition, manager.MaxXSpawnPosition);
        SpawnPoint.z = Random.Range(manager.MinZSpawnPosition, manager.MaxZSpawnPosition);

        
        SpawnPoint.y = myTerrain.SampleHeight(SpawnPoint) + GhostPrefab.transform.localScale.y / 2;
        return SpawnPoint;
    }
}