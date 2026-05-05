using UnityEngine;

public class DogAudioSource : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]private DogZone dogZone;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dogZone.OnPlayerEnterZone += PlayDogSound;
    }

    private void PlayDogSound() 
    {
        if (!audioSource.isPlaying) 
        {
            audioSource.Play();
        }
    }
}
