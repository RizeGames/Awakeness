using UnityEngine;

public class SpeakerPoleAudio : MonoBehaviour
{
    private AudioSource audioSource;
    //private SpeakerPoleDistance speakerPoleDistance;


    //private void OnEnable()
    //{
    //    speakerPoleDistance = GetComponent<SpeakerPoleDistance>();

    //    speakerPoleDistance.OnPlaySound += SpeakerPoleDistance_OnPlaySound;
    //    speakerPoleDistance.OnStopSound += SpeakerPoleDistance_OnStopSound;
    //}

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StopNoiseSound()
    {
        audioSource.Stop();
    }

    public void PlayNoiseSound()
    {
        audioSource.Play();
    }

    public bool SoundSourceState() 
    {
        return audioSource.isPlaying;
    }
}
