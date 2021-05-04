using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public float SpawnRatioTime;
    float TimeToNextBox;

    public GameObject BoxPrefab;
    GameManager manager;
    void Start()
    {

        manager = GetComponent<GameManager>();
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

        SpawnPoint.y = manager.MyTerrain.SampleHeight(transform.position);
        return SpawnPoint;
    }
}
