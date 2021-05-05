using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            other.GetComponent<GhostBehavior>().GhostHP -= 10;
            Destroy(this);
        }
    }
}
