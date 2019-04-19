using System.Collections;
using UnityEngine;



// Timer class to manage the game timer, attache it to the Controller Object.
public class Timer : MonoBehaviour
{

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

        
        
    }

    private void Start()
    {
        ResetTimer();
    }

    private void ResetTimer(int timer_in_secondnds = 120)
    {
        SetTimer = timer_in_secondnds;
        original_time = timer_in_secondnds;

        UpdateUITexts.instance.ResetTimerText();

        StopCoroutine(RunTimer());
        StartCoroutine(RunTimer());
    }

  
    private IEnumerator RunTimer()
    {
        while(SetTimer > 0)
        {
            yield return new WaitForSecondsRealtime(1);

            if(SetTimer <= original_time/3 )
            {
                // call set timer text color
                UpdateUITexts.instance.TimerTextColor(Color.red);
            }

            SetTimer --;

            UpdateUITexts.instance.UpdateTimerText(SetTimer);

            yield return null;
        }
    }
}
