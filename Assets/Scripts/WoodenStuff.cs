using System;
using UnityEngine;

public class WoodenStuff : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    private bool hasShown = false;

    [SerializeField] private float pushForce;
    [SerializeField] private AudioClip pushClip;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    if (!hasShown)
        //    {
        //        UISystem.Instance.InstructionBoxText.text = "Press 'E' to push the wooden stuff";
        //        UISystem.Instance.EnableInstructionBox();
        //        hasShown = true;
        //    }
        //    GameInput.instance.OnPushKeyPressed += GameInput_OnPushKeyPressed;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        GameInput.instance.OnPushKeyPressed -= GameInput_OnPushKeyPressed;
        UISystem.Instance.DisableInstructionBox();
    }

    private void GameInput_OnPushKeyPressed()
    {
        audioSource.PlayOneShot(pushClip);
        rb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
    }
}
