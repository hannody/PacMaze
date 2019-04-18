using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Detect a trigger with a collectable, requires a trigger collider, can be attached to root of the player.
public class Collectables : MonoBehaviour
{
    int score = 0;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == Tags.pickup)
        {
            other.GetComponent<Collider>().enabled = false;
            score++;
            print(score);
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
