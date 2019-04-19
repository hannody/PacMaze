
using UnityEngine;
// attach it to any enemy prefab
public class EnemyKillEvent : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == Tags.player && EnemyVulnerabilityController.instance.AllVulnerable == true)
        { 
            // Using eighter distance or rely on collsion/triggers are not presice, a better solution is to enforce this algorithm by using raycast hit to check if there is an object
            //(e.g. wall, obstacle) between the player and the enemy then check for distance or ray length, update is required in the future for this excersise..
             EnemyKill();
        }
    }


    private  void EnemyKill()
    {
        //this method can be used for some enemy death events such as player VFXs, SFX, death animation, etc..
        ScoringSystem.instance.SavedScore++;

        // Play death animation then
        gameObject.SetActive(false);
    }
}
