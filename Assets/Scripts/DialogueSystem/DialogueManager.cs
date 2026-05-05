using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public event Action OnStartDialouge;
    public event Action OnEndDialouge;
    public event Action<Dialogue> OnDialogueEnded;

    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialougeArea;
    [SerializeField] private float typingSpeed = 0.02f;

    private bool isDialougeActive = false;
    private bool isTyping = false;
    
    private Queue<DialougeLine> lines;
    private Dialogue currentDialogue;

    private WaitForSeconds wait;
    private Coroutine typeSentence;


    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    private void Start()
    {
        lines = new Queue<DialougeLine>();
        wait = new WaitForSeconds(typingSpeed);
    }

    public void StartDialouge(Dialogue dialouge) 
    {
        isDialougeActive = true;
        currentDialogue = dialouge;
        OnStartDialouge?.Invoke();
        lines.Clear();

        foreach ( DialougeLine line in dialouge.dialougeLines) 
        {
            lines.Enqueue(line);
        }

        DisplayNextDialougeLine();
    }

    public void DisplayNextDialougeLine() 
    {
        if (isTyping) return;

        if (lines.Count == 0) 
        {
            EndDialouge();
            return;
        }

        DialougeLine currentLine = lines.Dequeue();

        characterName.text = currentLine.character.characterName;

        StopAllCoroutines();

        typeSentence = StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence( DialougeLine dialougeLine) 
    {
        dialougeArea.text = "";

        foreach (char letter in dialougeLine.line)
        {
            dialougeArea.text += letter;
            isTyping = true;
            yield return wait;
        }

        isTyping = false;
    }


    private void EndDialouge() 
    {
        isDialougeActive = false;
        StopCoroutine(typeSentence);
        OnEndDialouge?.Invoke();
        OnDialogueEnded?.Invoke(currentDialogue);
    }


    public bool IsDialougeActive() 
    {
        return isDialougeActive;
    }


}
