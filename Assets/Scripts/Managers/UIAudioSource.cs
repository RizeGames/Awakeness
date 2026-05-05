using UnityEngine;

public class UIAudioSource : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip dialogueBoxSoundClip;
    [SerializeField] private AudioClip instructionBoxSoundClip;
   
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        UISystem.Instance.OnEnableDialogueBox += PlayDialogueBoxSound;
        UISystem.Instance.OnDisableDialogueBox += PlayDialogueBoxSound;

        UISystem.Instance.OnEnableInstructionBox += PlayInstructionBoxSound;
  
    }

    private void PlayDialogueBoxSound() 
    {
        audioSource.PlayOneShot(dialogueBoxSoundClip);
    }

    private void PlayInstructionBoxSound() 
    {
        audioSource.PlayOneShot(instructionBoxSoundClip);
    }
}
