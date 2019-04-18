using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Plain and straight forward score system that simply set/get scores using player prefs without any security (e.g. encryption)
public class ScoringSystem : MonoBehaviour
{
    public static ScoringSystem instance = null;
    public string score_key = "score";
    public int SavedScore { get; set; } = 0;

    private void Awake()
    {
        // Singleton

        //if we don't currently have a sound effect instance...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate
            Destroy(gameObject);


        // Get the last score if possible
        if (PlayerPrefs.HasKey(score_key))
        {
            try
            {
                SavedScore = PlayerPrefs.GetInt(score_key);
                UpdateUITexts.instance.UpdateScoreText(SavedScore);
            }
            catch(System.Exception e)
            {
                Debug.Log(e.Message + "at ==>"  + System.DateTime.Now.ToString("yyyy/M/dd "));
                SavedScore = 0;
                PlayerPrefs.SetInt(score_key, SavedScore);
            }
        }

    }

    public void SaveScore(int score)
    {
        if (score > 0)
        {
            try
            {
                SavedScore += score;
                PlayerPrefs.SetInt(score_key, SavedScore);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message + "at ==>" + System.DateTime.Now.ToString("yyyy/M/dd "));

            }
        }
    }
}
