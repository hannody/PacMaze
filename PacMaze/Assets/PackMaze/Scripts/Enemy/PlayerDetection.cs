﻿using UnityEngine;
using System.Collections;
public class PlayerDetection : MonoBehaviour
{
    public float stopChasingDuration = 5.5f;
    public float normalSightRadius = 0.05f;
    public float vulnerableSightRadius = 0.01f;

    private WanderingAI wanderAi;

    private Transform player;

    private void Awake()
    {
        wanderAi = transform.GetComponent<WanderingAI>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.player)
        {
            wanderAi.ChasePlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.player)
        {
            if (EnemyVulnerabilityController.instance.AllVulnerable == false)
            {
                // Start chasing the player only if status is not vulnerable
                StopCoroutine(StopChasing());
                StartCoroutine(StopChasing());
            }
            
        }
    }

    private void Update()
    {
        if(wanderAi.ChasePlayer == true && EnemyVulnerabilityController.instance.AllVulnerable  == false)
        {
            if(Vector3.Distance(transform.position, player.transform.position) < 2)
            {
                // the player is close enough for attacking
                PlayerDamage.instance.KillThePlayer();
                //print("Attack!!");
            }
        }

        // Last need improvement, but for this timed exercise's sake..
        if(EnemyVulnerabilityController.instance.AllVulnerable == true)
        {

            GetComponent<SphereCollider>().radius = vulnerableSightRadius;
        }
        else
        {
            GetComponent<SphereCollider>().radius = normalSightRadius;
        }
    }

    IEnumerator StopChasing()
    {
        yield return new WaitForSeconds(stopChasingDuration);
        wanderAi.ChasePlayer = false;
    }
}
