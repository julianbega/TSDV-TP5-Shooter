using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public Text Bullets;
    public Text TotalBulletsLeft;
    void Start()
    {
        gameManagerContainer = GameObject.Find("GameManager");
        gameManager = gameManagerContainer.GetComponent<GameManager>();
        Bullets.text = (ActualBullets + " / " + BulletsPerClip);
        TotalBulletsLeft.text = (TotalBullets.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(TotalBullets >= BulletsPerClip)
            { 
            TotalBullets -= BulletsPerClip;
            ActualBullets = BulletsPerClip;
            }
            else if (TotalBullets >= 0)
            {
                ActualBullets = TotalBullets;
                TotalBullets = 0;
            }
            else
            {
                ActualBullets = 0;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (ActualBullets > 0)
            {
                ActualBullets--;
                RaycastHit myHit;
                Vector3 MousePos;
                MousePos = Input.mousePosition;
                Ray myRay;
                myRay = CameraForGun.ScreenPointToRay(MousePos);


                if (Physics.Raycast(myRay.origin, myRay.direction * Range, out myHit))
                {

                    switch (GunID)
                    {
                        case 0:
                            if (myHit.transform.gameObject.tag == "Bomb")
                            {
                                Instantiate(myHit.transform.gameObject.GetComponent<Explotion>().Explosion, myHit.transform.position, Quaternion.identity);
                                Destroy(myHit.transform.gameObject);
                                gameManager.score = gameManager.score + gameManager.scoreForDestroyingBomb;
                                gameManager.bombsDestroyed++;
                            }
                            break;
                        case 1:
                            if (myHit.transform.gameObject.tag == "Ghost")
                            {                                
                                Destroy(myHit.transform.gameObject);
                                gameManager.score = gameManager.score + gameManager.scoreForKillingGhosts;
                                gameManager.ghostsKilled++;
                            }
                            break;
                        default:
                            break;
                    }
                    Debug.Log(myHit.transform.gameObject.tag);

                }
            }

        }

        Bullets.text = (ActualBullets + " / " + BulletsPerClip);
        TotalBulletsLeft.text = (TotalBullets.ToString());
    }


}
