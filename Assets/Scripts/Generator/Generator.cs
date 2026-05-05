using System;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GeneratorState currentState;

    [Header("References")]
    [SerializeField] private GameObject magnetField;
    [SerializeField] private GameObject lever;

    private bool hasShown = false;

    public event Action OnTurnedOn;
    public event Action OnTurnedOff;
    public event Action OnBroken;
    public event Action OnplayerEnters;
    public event Action OnplayerExits;

    private void TurnGeneratorOnAndOff()
    {
        if (currentState == GeneratorState.Off) 
        {
            TurnOn();
        }
        else if (currentState == GeneratorState.On)
        {
            TurnOff();
        }

        UISystem.Instance.DisableInstructionBox();
    }

    private void Start()
    {
        UpdateState();
    }

    private void TurnOn() 
    {
        if (currentState == GeneratorState.On) return;

        currentState = GeneratorState.On;
        UpdateState();  
    }

    private void TurnOff() 
    {
        if (currentState == GeneratorState.Off) return;
        currentState = GeneratorState.Off;
        UpdateState();
    }   

    private void UpdateState() 
    {
        switch (currentState) 
        {
            case GeneratorState.On:
                OnState();
                break;

            case GeneratorState.Off:
                OffState();
                break;

            case GeneratorState.Broken:
                BrokenState();
                break;
        }
    }

    private void OnState() 
    {
        Debug.Log("the generator is on");

        if (magnetField != null) 
        {
            magnetField.SetActive(true);
        }

        OnTurnedOn?.Invoke();
    }


    private void OffState()
    {
        Debug.Log("the generator is off");

        if (magnetField != null) 
        {
            magnetField.SetActive(false);
        }

        if (lever != null) 
        {
            lever.SetActive(true);
        }

        OnTurnedOff?.Invoke();
    }

    private void BrokenState() 
    {
        Debug.Log("the generator is broken");

        if (lever != null) 
        {
            lever.SetActive(false);
        }

        OnBroken?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
           
        //    if (currentState == GeneratorState.Broken) 
        //    {
        //        if (!InventorySystem.instance.GetHasItem()) 
        //        {
        //            UISystem.Instance.InstructionBoxText.text = "Find the lever to fix the generator";
        //            UISystem.Instance.EnableInstructionBox();
        //        }
        //        else 
        //        {
        //            OnplayerEnters?.Invoke();
        //            TurnOff();
        //            InventorySystem.instance.RemoveItem();
        //        }
        //    }
        //    else 
        //    {
        //        if (!hasShown)
        //        {
        //            UISystem.Instance.InstructionBoxText.text = "Press 'Q' to interact with the generator";
        //            UISystem.Instance.EnableInstructionBox();
        //            hasShown = true;
        //        }

        //        OnplayerEnters?.Invoke();
        //        GameInput.instance.OnInteractKeyPressed += TurnGeneratorOnAndOff;
        //    }

        //}
    }

   
    private void OnTriggerExit(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _))
        //{
        //    GameInput.instance.OnInteractKeyPressed -= TurnGeneratorOnAndOff;
        //    OnplayerExits?.Invoke();
        //    UISystem.Instance.DisableInstructionBox();
        //}
    }

}
