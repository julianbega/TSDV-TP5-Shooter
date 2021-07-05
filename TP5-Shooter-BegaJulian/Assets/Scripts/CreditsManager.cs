using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    GameObject gameManager;
   public GameManager gamemanager;

    public Text Points;
    public Text Boxes;
    public Text Ghosts;
    public Text Bombs;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gamemanager = gameManager.GetComponent<GameManager>();
        Bombs.text = ("you destroy: " + gamemanager.bombsDestroyed.ToString() + " bombs");
        Points.text = ("you make: " + gamemanager.score.ToString() + " points");
        Boxes.text = ("you collect: " + gamemanager.boxesCollected.ToString() + " boxes");
        Ghosts.text = ("you kill: " + gamemanager.ghostsKilled.ToString() + " ghosts");
    }

}
