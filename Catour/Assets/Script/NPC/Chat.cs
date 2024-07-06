using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chatText;
    [SerializeField] ChatText chat;
    void Start()
    {
        chatText.text = chat.GetChat();
    }


}
