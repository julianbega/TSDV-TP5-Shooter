using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    enum GunsIDs { Pistol, BallLauncher };
    public int GunID;
    public int TotalBullets;
    public int BulletsPerClip;
    public int ActualBullets;
    public int TimeToReload;
    public int Range;

    GameObject gameManagerContainer;
    GameManager gameManager;

    [SerializeField] Camera CameraForGun;
    void Start()
    {
        gameManagerContainer = GameObject.Find("GameManager");
        gameManager = gameManagerContainer.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit myHit;
            Vector3 MousePos;
            MousePos = Input.mousePosition;
            Ray myRay; 
            myRay = CameraForGun.ScreenPointToRay(MousePos);
            

            if(Physics.Raycast(myRay.origin, myRay.direction * Range, out myHit))
            {
                switch(GunID)
                {
                    case 0:
                        if(myHit.transform.gameObject.tag == "Bomb")
                        {
                            Instantiate(myHit.transform.gameObject.GetComponent<Explotion>().Explosion, myHit.transform.position, Quaternion.identity);                            
                            myHit.transform.gameObject.SetActive(false);
                            gameManager.points = gameManager.points + gameManager.PointsForDestroyingBomb;
                        }
                        break;
                    case 1:

                        break;
                    default:
                        break;
                }
                Debug.Log(myHit.transform.gameObject.tag);
            }
            

        }
    }

   
}
