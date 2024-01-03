using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemTube : MonoBehaviour
{
    public int tubeId;  // identifier number for tube

    // called when something enters the tube's collider
    void OnTriggerEnter2D (Collider2D col)
    {
        // check if it was the player
        if(col.CompareTag("Player"))
        {
            // tell the game manager that the player entered this tube
            GameManager.instance.OnPlayerEnterTube(tubeId);
        }
    }
}