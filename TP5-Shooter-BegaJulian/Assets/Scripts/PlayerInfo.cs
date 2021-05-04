using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInfo : MonoBehaviour
{



    public int PlayerHP;
    public Gun[] ActualGun;
    public int GunRange;

    public UnityEvent<int> changeUI; 
    void Start()
    {
        
    }

    void Update()
    {
        
        if (false)
        {
            changeUI?.Invoke(PlayerHP);

        }
    }
}
