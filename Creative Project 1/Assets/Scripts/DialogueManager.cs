using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueNode startNode;

    public CanvasGroup dialogueBox;
    public TMPro.TextMeshProUGUI dialogueTextField;

    public FlySpawner flySpawner;

    [Range(0.001f, 0.5f)]
    public float fadeDelay = 0.1f;

    DialogueNode currentNode;

    IEnumerator Start()
    {
        dialogueBox.alpha = 0;
        yield return new WaitForSeconds(1.5f);
        TriggerNextDialogue(startNode);
    }

    public void TriggerNextDialogue(DialogueNode node)
    {
        currentNode = node;
        StartCoroutine(FadeIn());
    }
    public void TriggerNextDialogue(int choice)
    {
        currentNode = currentNode.choices[choice];
        StartCoroutine(FadeIn());
    }

    public void CloseDialogue()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        dialogueTextField.text = currentNode.text;
        for (float a = 0.0f; a <= 1.0f; a += 0.025f)
        {
            dialogueBox.alpha = a;
            yield return new WaitForSeconds(fadeDelay);
        }
        dialogueBox.alpha = 1;
    }
    IEnumerator FadeOut()
    {
        dialogueTextField.text = currentNode.text;
        for (float a = 1.0f; a >= 0.0f; a -= 0.025f)
        {
            dialogueBox.alpha = a;
            yield return new WaitForSeconds(fadeDelay);
        }
        dialogueBox.alpha = 0;
    }
}