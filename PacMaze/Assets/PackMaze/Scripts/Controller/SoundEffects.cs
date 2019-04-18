using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects instance;
    public AudioClip pickUpClip;
    public AudioClip hitPlayerClip;
    public AudioClip hitRockClip;

    private AudioSource audio_s;
    private static bool isPlaying = false;

    private void Awake()
    {
        //if we don't currently have a sound effect instance...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate
            Destroy(gameObject);
    }
    void Start()
    {
        audio_s = transform.GetComponent<AudioSource>();

    }


    public void PlayPickUpClip()
    {

        if (pickUpClip != null)
        {
            audio_s.PlayOneShot(pickUpClip);

        }
        else
        {
            Debug.Log("Missing audio clip in PlayPickUpClip()");
        }

    }

    public void PlayHitPlayerClip()
    {
        if (hitPlayerClip != null)
        {
            audio_s.PlayOneShot(hitPlayerClip);

        }
        else
        {
            Debug.Log("Missing audio clip in PlayHitPlayerClip()");
        }
    }

    //public void PlayFireLoop()
    //{

    //    if (fireLoop != null)
    //    {
    //        StopCoroutine(FireLoopTimer(fireLoop));
    //        StartCoroutine(FireLoopTimer(fireLoop));

    //    }
    //    else
    //    {
    //        Debug.Log("Missing audio clip in  PlayFireLoop()");
    //    }

    //}




    //IEnumerator FireLoopTimer(AudioClip _clip)
    //{
    //    if (a.isPlaying)
    //    {
    //        yield return new WaitForSeconds(0.6f);
    //        audio_s.clip = _clip;
    //        audio_s.loop = true;
    //        audio_s.Play();
    //    }
    //    else
    //    {
    //        audio_s.clip = _clip;
    //        audio_s.loop = true;
    //        audio_s.Play();
    //    }
    //}

}