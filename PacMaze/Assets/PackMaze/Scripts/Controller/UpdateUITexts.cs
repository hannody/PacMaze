using UnityEngine;
using UnityEngine.UI;

public class UpdateUITexts : MonoBehaviour
{
    public static UpdateUITexts instance = null;

    public Text timer_text;
    public string timer_msg = "Time left:";


    public Text points_text;
    public string points_msg = "Points left:";


    public Text score_text;


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



        if (timer_text == null)
        {
            Debug.LogError("TimerText is not set i.e. null, plz set it in the inspector, for now will try to locate it by it's tag!");
            timer_text = GameObject.FindGameObjectWithTag(Tags.timer_text).GetComponent<Text>();
        }

        if (points_text == null)
        {
            Debug.LogError("PointsText is not set i.e. null, plz set it in the inspector, for now will try to locate it by it's tag!");
            points_text = GameObject.FindGameObjectWithTag(Tags.points_text).GetComponent<Text>();
        }

        if (score_text == null)
        {
            Debug.LogError("ScoreText is not set i.e. null, plz set it in the inspector, for now will try to locate it by it's tag!");
            score_text = GameObject.FindGameObjectWithTag(Tags.score_text).GetComponent<Text>();
        }

    }

    // TimerText area
    public void UpdateTimerText(int timer_val)
    {
        timer_text.text = string.Concat(timer_msg, timer_val.ToString());
    }

    public void ResetTimerText()
    {
        timer_text.text = timer_msg;

        //assuming the default color is white..
        timer_text.color = Color.white;
    }

    public void TimerTextColor(Color x)
    {
        timer_text.color = x;
    }
    //-------------------------------------------


    // Score Text Area
    public void UpdateScoreText(int score)
    {
        score_text.text = string.Concat("Score: ", score.ToString());
    }
    //-------------------------------------------


    // PointsText area
    public void UpdatePointsText(int points)
    {
        score_text.text = string.Concat(points_msg, points.ToString());
    }
    //-------------------------------------------
}
