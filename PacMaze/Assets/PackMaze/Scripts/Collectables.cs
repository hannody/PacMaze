using UnityEngine;


// Detect a trigger with a collectable, requires a trigger collider, can be attached to root of the player.
public class Collectables : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == Tags.pickup)
        {
            other.GetComponent<Collider>().enabled = false;

            // Aggregate the score, to be saved at the end of the game.
            ScoringSystem.instance.SavedScore++;

            //Update ScoreText 
            UpdateUITexts.instance.UpdateScoreText(ScoringSystem.instance.SavedScore);

            // Play the pick up sound sfx
            SoundEffects.instance.PlayPickUpClip();

            // Update the PointsText

            UpdateUITexts.instance.UpdatePointsText(--MazeSpawner.instance.Num_Points);

            other.gameObject.SetActive(false);
        }
    }
}
