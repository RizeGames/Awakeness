using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public static UISystem Instance;

    [SerializeField] private GameObject pickUpBox;
    [SerializeField] private GameObject itemImage;
    [SerializeField] private GameObject instructionBox;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject magnetSymbol;
    [SerializeField] private Image item;
    [SerializeField] private TextMeshProUGUI instructionBoxText;


    public event Action OnEnableDialogueBox;
    public event Action OnDisableDialogueBox;

    public event Action OnEnableInstructionBox;
   
    public Image Item 
    {
        get {  return item; }
        set {  item = value; }
    }

    public TextMeshProUGUI InstructionBoxText 
    {
        get { return instructionBoxText; }
        set { instructionBoxText.text = value.text; }
    }

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }


    private void Start()
    {
        DialogueManager.instance.OnStartDialouge += EnableDialogue;
        DialogueManager.instance.OnEndDialouge += DisableDialogue;
    }

    public void EnablePickUpBox() 
    {
        pickUpBox.SetActive(true);
    }

    public void DisablePickUpBox() 
    {
        pickUpBox.SetActive(false);
    }

    public void EnableItemImage() 
    {
        itemImage.gameObject.SetActive(true);
    }

    public void DisableItemImage()
    {
        itemImage.gameObject.SetActive(false);
    }

    public void EnableInstructionBox() 
    {
        instructionBox.SetActive(true);
        OnEnableInstructionBox?.Invoke();
    }

    public void DisableInstructionBox() 
    {
        instructionBox.SetActive(false);
    }

    public void EnableDialogue()
    {
        dialogue.SetActive(true);
        OnEnableDialogueBox?.Invoke();
    }

    public void DisableDialogue() 
    {
        dialogue.SetActive(false);
        OnDisableDialogueBox?.Invoke();
    }

    public void EnableMagnetSymbol() 
    {
        magnetSymbol.SetActive(true);
    }

    public void DisableMagnetSymbol() 
    {
        magnetSymbol.SetActive(false);
    }
}
