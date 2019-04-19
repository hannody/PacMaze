using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public static PlayerDamage instance = null;

    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    public void KillThePlayer()
    {
        // Set gameover bool to trigger save, gameover ui, etc..
        GameOverEvent.instance.GameOver();
        //play the death event of the player
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.enemy)
        {
            KillThePlayer();
        }
    }
}
