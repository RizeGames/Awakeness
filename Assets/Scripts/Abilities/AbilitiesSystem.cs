using System;
using UnityEngine;
public class AbilitiesSystem : MonoBehaviour
{
    public static AbilitiesSystem Instance;

    private bool isMagneticAbilityUnlocked = false;
    private AudioSource audioSource;

    [SerializeField] private AudioClip magneticAbiliySound;

    public event Action OnAbilityGetsReady;
    public event Action OnAbilityDoesNotGetReady;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }


    public void UnlockTheMagneticAbility() 
    {
        isMagneticAbilityUnlocked = true;
        UISystem.Instance.EnableMagnetSymbol();
    }

    public bool IsMagneticAbilityUnlocked() 
    {
        return isMagneticAbilityUnlocked;
    }

    public void ImplementOnAbilityGetsReady() 
    {
        OnAbilityGetsReady?.Invoke();
    }

    public void ImplementOnAbilityDoesNotGetReady() 
    {
        OnAbilityDoesNotGetReady?.Invoke();
    }

    public void PlayMagneticAbilitySound() 
    {
        audioSource.PlayOneShot(magneticAbiliySound);
    }
}
