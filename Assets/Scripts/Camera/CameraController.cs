using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float distance = 5;
    [SerializeField] private float height = 7;
    [SerializeField] private float minVerticalAngle = -45;
    [SerializeField] private float maxVerticalAngle = 45;
    [SerializeField] private Vector2 framingOffset;
    [SerializeField] private float rotationSpeed = 2;

    private CameraInput cameraInput;
    private float rotationY;
    private float rotationX;

    
    private void Awake()
    {
        cameraInput = GetComponent<CameraInput>();
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        rotationY += cameraInput.MouseX * rotationSpeed;

        rotationX += cameraInput.MouseY * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPosition = followTarget.position + new Vector3(framingOffset.x,framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, height ,distance);
        transform.rotation = targetRotation;
    }

    // this method will n the rotation of the camera on the horizontal plane, which is used by the player controller to move the player in the direction of the camera's forward vector.
    public Quaternion GetPlanerRotation()
    {
        return Quaternion.Euler(0, rotationY, 0);
    }
}
