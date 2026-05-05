using UnityEngine;

public class BrokenRobotTrigger : MonoBehaviour
{

    private BrokenRobot brokenRobot;
   
    private void Awake()
    {
        brokenRobot = GetComponent<BrokenRobot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    GameInput.instance.OnInteractKeyPressed += brokenRobot.InteractWithBrokenRobot;
        //    UISystem.Instance.InstructionBoxText.text = "Press 'Q' to interact";
        //    UISystem.Instance.EnableInstructionBox();
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _))
        //{
        //    GameInput.instance.OnInteractKeyPressed -= brokenRobot.InteractWithBrokenRobot;
        //    UISystem.Instance.DisableInstructionBox();
        //}
    }
}
