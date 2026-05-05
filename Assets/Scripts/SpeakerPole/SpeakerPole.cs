using UnityEngine;

public class SpeakerPole : MonoBehaviour
{
    [SerializeField] private float playDistance = 70f;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private PlayerAnimation playerAnimation;
    //[SerializeField] private Player player;
    [SerializeField] private CameraAnimation cameraAnimation;

    private SpeakerPoleAudio speakerPoleAudio;
    private SpeakerPoleDistance speakerPoleDistance;
    private bool isMuted = false;


    private void Awake()
    {
        speakerPoleAudio = GetComponent<SpeakerPoleAudio>();
        speakerPoleDistance = GetComponent<SpeakerPoleDistance>();
    }

    private void Update()
    {
        speakerPoleDistance.CalculateDistance(playerPosition);

        if (speakerPoleDistance.Distance <= playDistance && !speakerPoleAudio.SoundSourceState() && !isMuted) 
        {
            //player.MoveSpeed = 5f;
            speakerPoleAudio.PlayNoiseSound();
            playerAnimation.SetHurtLayerActive(true);
            PostProcessController.Instance.DisableNormalVolume();
            PostProcessController.Instance.EnableDarkVolume();
            cameraAnimation.SetLongCameraShakeTrue();
        }
        else if (speakerPoleDistance.Distance > playDistance && isMuted )
        {
            //player.MoveSpeed = 10f;
            speakerPoleAudio.StopNoiseSound();
            playerAnimation.SetHurtLayerActive(false);
            PostProcessController.Instance.DisableDarkVolume();
            PostProcessController.Instance.EnableNormalVolume();
            cameraAnimation.SetLongCameraShakeFalse();
        }
    }

    public void MuteSpeakerPole()
    {
        //player.MoveSpeed = 10f;
        isMuted = true;
        speakerPoleAudio.StopNoiseSound();
        playerAnimation.SetHurtLayerActive(false);
        PostProcessController.Instance.DisableDarkVolume();
        PostProcessController.Instance.EnableNormalVolume();
        cameraAnimation.SetLongCameraShakeFalse();
        UISystem.Instance.DisableInstructionBox();
    }
}
