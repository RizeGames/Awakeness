using UnityEngine;

public class RadioAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private Radio radio;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        radio = GetComponent<Radio>();
    }

    private void Start()
    {
        radio.OnRadioTurnedOn += PlayAudio;
    }


    public void PlayAudio() 
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
