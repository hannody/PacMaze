using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicPlayer : MonoBehaviour
{
    public AudioClip[] bgMusic;
    public float volume;
    public bool loopOneMusic = false;
    public bool randomPlay = false;
    public bool muteMusic = false;
    public GameObject muteBtn;
    public GameObject unMuteBtn;

    private int musicIndex = 0;
    private AudioSource backgroundMusicSource;
    private string muteMusicKey = "muteSound";

    private AudioSource CreateAudioSource(AudioClip clip, bool loop, float volume)
    {
        GameObject go = new GameObject("audio");
        go.transform.parent = transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.AddComponent(typeof(AudioSource));
        go.GetComponent<AudioSource>().clip = clip;
        go.GetComponent<AudioSource>().loop = loop;
        go.GetComponent<AudioSource>().volume = volume;
        go.GetComponent<AudioSource>().Play();
        return go.GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if (unMuteBtn != null && muteBtn != null)
        {
            if (PlayerPrefs.GetInt(muteMusicKey) == 0)
            {
                muteMusic = false;
                unMuteBtn.SetActive(false);
                muteBtn.SetActive(true);
            }
            else
            {
                muteMusic = true;
                unMuteBtn.SetActive(true);
                muteBtn.SetActive(false);
            }
        }
    }

    void Start()
    {

        if (bgMusic.Length != 0)
        {

            if (randomPlay)
                musicIndex = Random.Range(0, bgMusic.Length);
            backgroundMusicSource = CreateAudioSource(bgMusic[musicIndex], loopOneMusic, volume);
            musicIndex++;
        }
    }
    public void MuteMusic(bool mute)
    {
        muteMusic = mute;

        if (mute == false)
        {
            PlayerPrefs.SetInt(muteMusicKey, 0);
        }
        else
        {
            PlayerPrefs.SetInt(muteMusicKey, 1);
        }
    }
    void Update()
    {

        if (muteMusic == false)
        {
            if (backgroundMusicSource)
            {
                backgroundMusicSource.loop = loopOneMusic;
                if (!backgroundMusicSource.isPlaying)
                {
                    if (bgMusic.Length != 0)
                    {
                        if (musicIndex >= bgMusic.Length) musicIndex = 0;
                        if (randomPlay)
                            musicIndex = Random.Range(0, bgMusic.Length);

                        backgroundMusicSource.GetComponent<AudioSource>().clip = bgMusic[musicIndex];
                        musicIndex++;

                        backgroundMusicSource.Play();
                    }
                }
            }

            backgroundMusicSource.GetComponent<AudioSource>().pitch = GetComponent<AudioSource>().pitch;
            backgroundMusicSource.GetComponent<AudioSource>().volume = volume;
        }
        else
        {
            backgroundMusicSource.Stop();
        }


    }

    public void ChangeVolume(float vol)
    {
        volume = vol;
    }
}
