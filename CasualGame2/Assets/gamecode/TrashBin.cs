using UnityEngine;

// This script is responsible for handling the trashbin to recieve objects,
// play sound effect, update the score data, and display it to the text UI 
// of the score
public class TrashBin : MonoBehaviour
{
    public string acceptableTag = "organik";

    //sfx
    public AudioClip audioClipRight, audioClipWrong;
    public AudioSource SFXAudioSource;

    Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawnpoint").GetComponent<Spawner>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals(acceptableTag))
        {
            Data.Score += 25;

            // deactivate the object using the method made in its script
            collider.GetComponent<SpriteMove>().Deactivate();

            // to keep populating the game scene with objects
            // without waiting for the spawn delay
            //spawner.Spawn(); //this makes the game harder

            // SFX
            SFXAudioSource.clip = audioClipRight;
            SFXAudioSource.Play();
        }
        else
        {
            Data.Score -= 5;
            Data.Wrong += 1;

            // deactivate the object using the method made in its script
            collider.GetComponent<SpriteMove>().Deactivate();

            // to keep populating the game scene with objects
            // without waiting for the spawn delay
            //spawner.Spawn(); //this makes the game harder

            // SFX
            SFXAudioSource.clip = audioClipWrong;
            SFXAudioSource.Play();
        }
    }
}
