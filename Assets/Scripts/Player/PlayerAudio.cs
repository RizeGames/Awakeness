using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] dirtSounds;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootStep()
    {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(dirtSounds[Random.Range(0, dirtSounds.Length)]);
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
