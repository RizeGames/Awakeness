using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;


    public float HorizontalInput
    {
        get { return horizontalInput; }
        private set { horizontalInput = value; }
    }

    public float VerticalInput
    {
        get { return verticalInput; }
        private set { verticalInput = value; }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
}
