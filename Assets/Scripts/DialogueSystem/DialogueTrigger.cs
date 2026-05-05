using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueCharacter  
{
    public string characterName;
}

[System.Serializable]
public class DialougeLine 
{
    public DialogueCharacter character;

    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{

    public List<DialougeLine> dialougeLines = new List<DialougeLine>();
}


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue afterDoTaskDialogue;
    [SerializeField] private Dialogue beforeDoTaskDialogue;
    [SerializeField] private GameObject cageDoor;

    private void Start()
    {
        DialogueManager.instance.OnDialogueEnded += HandleDialogueEnd;
    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    UISystem.Instance.InstructionBoxText.text = "Press 'T' to Talk";
        //    UISystem.Instance.EnableInstructionBox();

        //    if (InventorySystem.instance.GetHasItem()) 
        //    {
        //        GameInput.instance.OnStartDialoguePressed += StartAfterDoTaskDialogue;
        //    }
        //    else 
        //    {
        //        GameInput.instance.OnStartDialoguePressed += StartBeforeDoTaskDialogue;
        //    }
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    UISystem.Instance.DisableInstructionBox();

        //    GameInput.instance.OnStartDialoguePressed -= StartAfterDoTaskDialogue;
        //    GameInput.instance.OnStartDialoguePressed -= StartBeforeDoTaskDialogue;
        //}
    }

    private void StartAfterDoTaskDialogue() 
    {
        UISystem.Instance.DisableInstructionBox();
        DialogueManager.instance.StartDialouge(afterDoTaskDialogue);
    }

    private void StartBeforeDoTaskDialogue() 
    {
        UISystem.Instance.DisableInstructionBox();
        DialogueManager.instance.StartDialouge(beforeDoTaskDialogue);
    }

    private void HandleDialogueEnd(Dialogue endedDialogue) 
    {
        if (endedDialogue == afterDoTaskDialogue) 
        {
            AbilitiesSystem.Instance.UnlockTheMagneticAbility();
            Destroy(gameObject);
            Destroy(cageDoor);
            InventorySystem.instance.RemoveItem();
        }
    }
}
