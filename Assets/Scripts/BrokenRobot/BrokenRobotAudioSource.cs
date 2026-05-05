using UnityEngine;

public class BrokenRobotAudioSource : MonoBehaviour
{
    private AudioSource audioSource;
    private BrokenRobot brokenRobot;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        brokenRobot = GetComponent<BrokenRobot>();
    }

    private void Start()
    {
        brokenRobot.OnInteractWithBrokenRobot += PlayAudioSource;
    }

    private void PlayAudioSource()
    {
        if (audioSource != null && !audioSource.isPlaying) 
        {
            audioSource.Play();
        }
    }

}
