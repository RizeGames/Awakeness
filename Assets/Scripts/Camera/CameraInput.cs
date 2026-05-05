using UnityEngine;

public class CameraInput : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    public float MouseX
    {
        get { return mouseX; }
        private set { mouseX = value; }
    }

    public float MouseY
    {
        get { return mouseY; }
        private set { mouseY = value; }
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }
}
