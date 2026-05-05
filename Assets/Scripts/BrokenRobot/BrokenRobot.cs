using System;
using UnityEngine;

public class BrokenRobot : MonoBehaviour
{
    
    public event Action OnInteractWithBrokenRobot;

    public void InteractWithBrokenRobot() 
    {
        OnInteractWithBrokenRobot?.Invoke();
        UISystem.Instance.DisableInstructionBox();
    }
}
