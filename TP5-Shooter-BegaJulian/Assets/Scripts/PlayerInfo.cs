using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerInfo : MonoBehaviour
{



    public int PlayerHP;
    public Text HP;
    public Gun[] ActualGun;

    public GameManager gameManager;

    public UnityEvent<int> changeUI; 
    void Start()
    {
        HP.text = ("HP: "+PlayerHP);
    }

    void Update()
    {
        HP.text = ("HP: " + PlayerHP);
        if (PlayerHP <= 0)
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
        if (other.gameObject.tag == "Box")
        {
            gameManager.points += gameManager.PointsPerBox;
            gameManager.boxesCollected++;
            Destroy(other);
        }
    }
}
