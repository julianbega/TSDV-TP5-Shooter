using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{
    public float timeToDeleteItself;
    void Update()
    {
        timeToDeleteItself -= Time.deltaTime;
        if (timeToDeleteItself <= 0) Destroy(this.gameObject);
    }
}
