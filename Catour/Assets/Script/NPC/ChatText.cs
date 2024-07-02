using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ChatText : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string chat = "Enter new chat text here";
    public string GetChat()
    {
        return chat;
    }

}
