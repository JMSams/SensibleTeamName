using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueNode startNode;

    public TMPro.TextMeshProUGUI dialogueBox;

    DialogueNode currentNode;

    void Start()
    {
        TriggerNextDialogue(startNode);
    }

    public void TriggerNextDialogue(DialogueNode node)
    {
        currentNode = node;
        StartCoroutine(TypeWriter(node.text));
    }
    public void TriggerNextDialogue(int choice)
    {
        currentNode = currentNode.choices[choice];
        StartCoroutine(TypeWriter(currentNode.text));
    }

    IEnumerator TypeWriter(string text, float secondsPerChar = 0.05f)
    {
        dialogueBox.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            dialogueBox.text += text[i];
            yield return new WaitForSeconds(secondsPerChar);
        }
    }
}