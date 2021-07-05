using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public float SpawnRatioTime;
    float TimeToNextBox;

    public GameObject BoxPrefab;
    public GameManager manager;
    Terrain myTerrain;
    void Start()
    {
        myTerrain = FindObjectOfType<Terrain>();
        TimeToNextBox = SpawnRatioTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextBox -= Time.deltaTime;

        if (TimeToNextBox <= 0)
        {
            TimeToNextBox = SpawnRatioTime;
            Instantiate(BoxPrefab, SpawnBox(), Quaternion.identity);
            
        }
        

    }
    Vector3 SpawnBox()
    {
        Vector3 SpawnPoint = new Vector3(0, 0, 0);
        SpawnPoint.x = Random.Range(manager.MinXSpawnPosition, manager.MaxXSpawnPosition);
        SpawnPoint.z = Random.Range(manager.MinZSpawnPosition, manager.MaxZSpawnPosition);

        SpawnPoint.y = myTerrain.SampleHeight(SpawnPoint) + BoxPrefab.transform.localScale.y/2;
        return SpawnPoint;
    }
}
