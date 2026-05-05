using UnityEngine;

public class GeneratorSound : MonoBehaviour
{
    [SerializeField] private AudioClip generatorOn;
    [SerializeField] private AudioClip generatorOff;

    private AudioSource audioSource;
    private Generator generator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        generator = GetComponent<Generator>();
        generator.OnplayerEnters += AddGeneratorSounds;
        generator.OnplayerExits += RemoveGeneratorSounds;
    }

    private void AddGeneratorSounds()
    {
        generator.OnTurnedOn += PlayGeneratorOnSound;
        generator.OnTurnedOff += PlayGeneratorOffSound;
    }

    private void RemoveGeneratorSounds()
    {
        generator.OnTurnedOn -= PlayGeneratorOnSound;
        generator.OnTurnedOff -= PlayGeneratorOffSound;
    }

    private void PlayGeneratorOnSound()
    {
        audioSource.PlayOneShot(generatorOn);
    }

    private void PlayGeneratorOffSound()
    {
        audioSource.PlayOneShot(generatorOff);
    }
}
