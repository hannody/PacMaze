using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
