using UnityEngine;

public class CrouchArea : MonoBehaviour
{
    private bool isInside = false;
    private bool isCrouchKeyPressed = false;
    private PlayerAnimation playerAnimation;
    //private Player player;
    private PlayerAudio footSteps;
  

    private void Start()
    {
        playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        footSteps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAudio>();
    }

    private void Update()
    {
        
        if (isInside && !isCrouchKeyPressed) 
        {
            playerAnimation.SetCrouchLayerActive(false);
            //player.MoveSpeed = 10f;
            footSteps.GetAudioSource().volume = 1f;
        }
        else if (isInside && isCrouchKeyPressed) 
        {
            playerAnimation.SetCrouchLayerActive(true);
            //player.MoveSpeed = 5f;
            footSteps.GetAudioSource().volume = 0.2f;
            UISystem.Instance.DisableInstructionBox();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       //if (other.TryGetComponent<Player>(out _)) 
       //{
       //     isInside = true;
       //     GameInput.instance.OnCrouchKeyStarted += Instance_OnCrouchKeyStarted;
       //     GameInput.instance.OnCrouchKeyCanceled += Instance_OnCrouchKeyCanceled;
       //     UISystem.Instance.InstructionBoxText.text = "Press 'C' to crouch";
       //     UISystem.Instance.EnableInstructionBox();
       // }
    }

    private void Instance_OnCrouchKeyStarted()
    {
         isCrouchKeyPressed = true;
    }

    private void Instance_OnCrouchKeyCanceled()
    {
        isCrouchKeyPressed = false;
    }


    private void OnTriggerExit(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    UISystem.Instance.DisableInstructionBox();
        //    GameInput.instance.OnCrouchKeyStarted -= Instance_OnCrouchKeyStarted;
        //    GameInput.instance.OnCrouchKeyCanceled -= Instance_OnCrouchKeyCanceled;
        //    isInside = false;
        //    isCrouchKeyPressed = false;
        //}
    }
}
