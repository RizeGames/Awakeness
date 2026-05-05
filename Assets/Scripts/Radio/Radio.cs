using System;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public event Action OnRadioTurnedOn;


    public void TurnRadioOn()
    {
        OnRadioTurnedOn?.Invoke();
        UISystem.Instance.DisableInstructionBox();
    }
}
