using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverEvent : MonoBehaviour
{
    public static GameOverEvent instance = null;

    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    public void GameOver()
    {
        //Show game over menu

        //save the score
        ScoringSystem.instance.SaveScore();
        UIGameOverController.instance.EnableGameOverPanel(true);
    }
}
