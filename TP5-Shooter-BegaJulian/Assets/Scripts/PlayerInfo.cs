using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerInfo : MonoBehaviour
{



    public int PlayerHP;
    public Text HP;
    public int ActualGun;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActualGun = 0;
            activatePistol();
            deActivateBallThrower();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActualGun = 1;
            deActivatePistol();
            activateBallThrower();

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
        if (other.gameObject.tag == "Ghost")
        {
            PlayerHP -= 10;
        }
    }

    public void activateBallThrower()
    {
        GameObject.Find("BallThrower").gameObject.GetComponent<Gun>().enabled = true;
        GameObject.Find("BallThrowerBigHandler").gameObject.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("BallThrowerCannon").gameObject.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("BallThrowerCharger").gameObject.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("BallThrowerSmallHandler").gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    public void deActivateBallThrower()
    {
        GameObject.Find("BallThrower").gameObject.GetComponent<Gun>().enabled = false;
        GameObject.Find("BallThrowerBigHandler").gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("BallThrowerCannon").gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("BallThrowerCharger").gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("BallThrowerSmallHandler").gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    public void activatePistol()
    {
        GameObject.Find("Pistol").gameObject.GetComponent<Gun>().enabled = true;
        GameObject.Find("Pistol").gameObject.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("PistolHandler").gameObject.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("PistolTrigerHandler").gameObject.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("PistolTrigger").gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    public void deActivatePistol()
    {
        GameObject.Find("Pistol").gameObject.GetComponent<Gun>().enabled = false;
        GameObject.Find("Pistol").gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("PistolHandler").gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("PistolTrigerHandler").gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("PistolTrigger").gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
