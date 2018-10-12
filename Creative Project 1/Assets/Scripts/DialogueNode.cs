using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Node", menuName = "Dialogue Node", order = 0)]
public class DialogueNode : ScriptableObject
{
    [TextArea(3, 8)]
    public string text;

    public DialogueNode[] choices;
}