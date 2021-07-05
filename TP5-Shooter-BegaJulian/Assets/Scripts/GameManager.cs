using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    public int scoreForDestroyingBomb;    
    public int bombsDestroyed;

    public int scoreForKillingGhosts;
    public int ghostsKilled;

    public int scorePerBox;
    public int boxesCollected;


    public float MinXSpawnPosition;
    public float MaxXSpawnPosition;
    public float MinZSpawnPosition;
    public float MaxZSpawnPosition;

    public SceneLoader SceneController;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
