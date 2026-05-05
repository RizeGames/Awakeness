using UnityEngine;

public class SpeakerPoleTrigger : MonoBehaviour
{
    private SpeakerPole speakerPole;
    private bool hasShown = false;

    private void Awake()
    {
        speakerPole = GetComponent<SpeakerPole>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    if (!hasShown)
        //    {
        //        UISystem.Instance.InstructionBoxText.text = "Press 'Q' to mute the speaker pole";
        //        UISystem.Instance.EnableInstructionBox();
        //        hasShown = true;
        //    }
        //    GameInput.instance.OnInteractKeyPressed += speakerPole.MuteSpeakerPole;
        //}
    }

    
    private void OnTriggerExit(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    UISystem.Instance.DisableInstructionBox();
        //    GameInput.instance.OnInteractKeyPressed -= speakerPole.MuteSpeakerPole;
        //}
    }

}
