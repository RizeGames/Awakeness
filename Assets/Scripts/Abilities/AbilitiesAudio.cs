using UnityEngine;

public class AbilitiesAudio : MonoBehaviour
{
    [SerializeField] private AudioClip abilityIsReady;
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        AbilitiesSystem.Instance.OnAbilityGetsReady += PlayAbilityIsReadySound;
    }


    private void PlayAbilityIsReadySound()
    {
        audioSource.PlayOneShot(abilityIsReady);
    }
}
