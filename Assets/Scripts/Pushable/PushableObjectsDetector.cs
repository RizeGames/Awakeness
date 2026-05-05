using UnityEngine;

public class PushableObjectsDetector : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CameraAnimation cameraAnimation;
    
    private Rigidbody magneticObjectRb;
    private CurrentStatePushableObject currentStatePushableObject;

    private float force = 2000f;
    private bool hasShown = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PushableObject")) 
        {
            
            if (AbilitiesSystem.Instance.IsMagneticAbilityUnlocked())
            {
                if (other.GetComponent<CurrentStatePushableObject>().IsPushed)
                {
                    return;
                }
                else
                {
                    AbilitiesSystem.Instance.ImplementOnAbilityGetsReady();

                    UISystem.Instance.InstructionBoxText.text = "Press '1' to use the magnetic ability";

                    if (!hasShown)
                    {
                        UISystem.Instance.EnableInstructionBox();
                        hasShown = true;
                    }

                    magneticObjectRb = other.gameObject.GetComponent<Rigidbody>();
                    currentStatePushableObject = other.gameObject.GetComponent<CurrentStatePushableObject>();

                    GameInput.instance.OnFirstAbilityKeyPressed += ApplyForce;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PushableObject"))
        {
            AbilitiesSystem.Instance.ImplementOnAbilityDoesNotGetReady();
            magneticObjectRb = null;
            GameInput.instance.OnFirstAbilityKeyPressed -= ApplyForce;
            UISystem.Instance.DisableInstructionBox();
        }
    }

    private void ApplyForce() 
    {
        AbilitiesSystem.Instance.PlayMagneticAbilitySound();
        magneticObjectRb.AddForce(player.transform.forward * force, ForceMode.Impulse);
        currentStatePushableObject.IsPushed = true;
        cameraAnimation.SetCameraTrigger();
        UISystem.Instance.DisableInstructionBox();
    }
}
