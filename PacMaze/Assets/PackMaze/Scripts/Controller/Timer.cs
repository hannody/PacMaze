using System.Collections;
using UnityEngine;
using UnityEngine.UI;


// Timer class to manage the game timer, attache it to the Controller Object.
public class Timer : MonoBehaviour
{
    public string timer_msg = "Remaining Time:";
    public Text timer_text;

    public int SetTimer { get; set; } = 120;

    public static Timer instance;

    private int original_time;

    private void Awake()
    {
        //Singleton
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if (timer_text == null)
        {
            Debug.LogError("TimerText is not set i.e. null, plz set it in the inspector, for now will try to locate it by it's tag!");
            timer_text = GameObject.FindGameObjectWithTag(Tags.timer_text).GetComponent<Text>();
        }
        ResetTimer();
    }

    private void ResetTimer(int timer_in_secondnds = 120)
    {
        SetTimer = timer_in_secondnds;
        original_time = timer_in_secondnds;

        ResetTimerText();

        StopCoroutine(RunTimer());
        StartCoroutine(RunTimer());
    }

    private void ResetTimerText()
    {
        timer_text.text = timer_msg;

        //assuming the default color is white..
        timer_text.color = Color.white;
    }
    private IEnumerator RunTimer()
    {
        while(SetTimer > 0)
        {
            yield return new WaitForSecondsRealtime(1);

            if(SetTimer <= original_time/3 )
            {
                timer_text.color = Color.red;
            }

            SetTimer --;

            timer_text.text = string.Concat(timer_msg, SetTimer.ToString());

            yield return null;
        }
    }
}
