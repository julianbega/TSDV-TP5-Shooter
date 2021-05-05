using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;

    public int PointsForDestroyingBomb;    
    public int bombsDestroyed;

    public int PointsForKillingGhosts;
    public int ghostsKilled;

    public int PointsPerBox;
    public int boxesCollected;


    public float MinXSpawnPosition;
    public float MaxXSpawnPosition;
    public float MinZSpawnPosition;
    public float MaxZSpawnPosition;

    public Terrain MyTerrain;
    public SceneLoader SceneController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
