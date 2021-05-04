using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInfo : MonoBehaviour
{



    public int PlayerHP;
    public Gun[] ActualGun;

    public GameManager gameManager;

    public UnityEvent<int> changeUI; 
    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerHP <= 0)
        {
            gameManager.SceneController.LoadScene("Credits");
        }
        if (false)
        {
            changeUI?.Invoke(PlayerHP);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            PlayerHP -= 50;
           
           
        }
    }
}
