using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public NewActions inputActions;

    public static GameInput instance;

    public event Action OnPushKeyPressed;
    public event Action OnInteractKeyPressed;
    public event Action OnCrouchKeyStarted;
    public event Action OnCrouchKeyCanceled;
    public event Action OnStartDialoguePressed;
    public event Action OnFirstAbilityKeyPressed;

    private void Awake()
    {
        inputActions = new NewActions();

        if (instance == null) 
        {
            instance = this;
        }

        inputActions.Player.Push.performed += ctx => OnPushKeyPressed?.Invoke();
        inputActions.Player.Interact.performed += ctx => OnInteractKeyPressed?.Invoke();
        inputActions.Player.Crouch.started += ctx => OnCrouchKeyStarted?.Invoke();
        inputActions.Player.Crouch.canceled += ctx => OnCrouchKeyCanceled?.Invoke();
        inputActions.Player.StartDialogue.performed += ctx => OnStartDialoguePressed?.Invoke();
        inputActions.Player.FirstAbility.performed += ctx => OnFirstAbilityKeyPressed?.Invoke();

        inputActions.Enable();
    }

  
}
