using UnityEngine;

public class RadioTrigger : MonoBehaviour
{
    private bool hasShown = false;
    private Radio radio;


    private void Awake()
    {
        radio = GetComponent<Radio>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _))
        //{
        //    if (!hasShown)
        //    {
        //        UISystem.Instance.InstructionBoxText.text = "Press 'Q' to turn on the radio";
        //        UISystem.Instance.EnableInstructionBox();
        //        hasShown = true;
        //    }

        //    GameInput.instance.OnInteractKeyPressed += radio.TurnRadioOn;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _))
        //{
        //    GameInput.instance.OnInteractKeyPressed -= radio.TurnRadioOn;
        //    UISystem.Instance.DisableInstructionBox();
        //}
    }
}
