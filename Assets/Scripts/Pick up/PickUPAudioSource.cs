using System.Runtime.CompilerServices;
using UnityEngine;

public class PickUPAudioSource : MonoBehaviour
{
    private AudioSource audioSource;
    private PickUpItem pickUpItem;

    [SerializeField] private AudioClip clip;



    private void Start()
    {
        pickUpItem = GetComponent<PickUpItem>();

        pickUpItem.OnItemPickedUp += PlayPickUpSound;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayPickUpSound() 
    {
        audioSource.PlayOneShot(clip);
    }

    public float GetClipLenght() 
    {
        return clip.length;
    }
}
