using UnityEngine;

public class MagnetLever : MonoBehaviour
{
    [SerializeField] private Generator generator;
    [SerializeField] private GameObject car;
    [SerializeField] private Transform magneticPoint;
    [SerializeField] private CameraAnimation cameraAnimation;

    private float pullingForce = 4000f;
    private bool isGeneratorOn = false;
   
    private void OnEnable()
    {
        generator.OnTurnedOn += Generator_OnTurnedOn;
    }

    private void Generator_OnTurnedOn()
    {
        isGeneratorOn = true;

        if(cameraAnimation != null) 
        {
            cameraAnimation.SetCameraTrigger();
        }
    }

    private void FixedUpdate()
    {
        if (isGeneratorOn) 
        {
            Vector3 distance = (magneticPoint.position - car.transform.position).normalized;

            Rigidbody rb = car.GetComponent<Rigidbody>();

            rb.AddForce(distance * pullingForce, ForceMode.Force);
        }
     
    }
}
