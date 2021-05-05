using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    public enum EnemyState
    {
        Erratic, 
        Chasing, 
        Last,
    }

    [SerializeField] private EnemyState state;

    public float GhostHP = 30;
    public float Speed = 2;
    public float DistanceToChase = 7;

    Transform Player;

    private float time;
    public float timeForErraticMove = 2;
    public float minDistance = 1f;
    public float maxDistance = 2f;

    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        switch (state)
        {
            case EnemyState.Erratic:
                if (time <= 0)
                {
                    time = timeForErraticMove;
                    float randomY = Random.Range(0, 360);
                    this.transform.Rotate(0.0f, randomY, 0.0f, Space.Self);
                    transform.position += transform.forward * Random.Range(minDistance, maxDistance);
                }
                if (Vector3.Distance(transform.position, Player.position) < DistanceToChase)
                {
                    NextState();
                }
                break;
            case EnemyState.Chasing:
                if (Vector3.Distance(transform.position, Player.position) > DistanceToChase)
                {
                    NextState();
                }
                else
                {
                    Vector3 dir = Player.position - transform.position;
                    transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World); //, Space.World);
                }           
                break;
           
        }
    }

    private void NextState()
    {
        if (state == EnemyState.Erratic)
        {
            state = EnemyState.Chasing;
        }
        else 
        {            
            state = EnemyState.Erratic;
        }
    }

    
}
