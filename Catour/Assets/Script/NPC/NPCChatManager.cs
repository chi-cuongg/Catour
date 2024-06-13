using UnityEngine;
using UnityEngine.UI;

public class NPCChatManager : MonoBehaviour
{
    public GameObject npcChatPanel;  // Panel chứa nội dung chat
    public Text npcChatText;  // Đối tượng Text hiển thị nội dung chat

    private bool isChatVisible = false;

    void Start()
    {
        if (npcChatPanel == null || npcChatText == null)
        {
            Debug.LogError("NPC Chat Panel or Text is not assigned in the inspector.");
            return;
        }

        // Ẩn khung chat khi bắt đầu
        npcChatPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleChat();
        }
    }

    void ToggleChat()
    {
        isChatVisible = !isChatVisible;
        npcChatPanel.SetActive(isChatVisible);

        if (isChatVisible)
        {
            UpdateChatText("Hello! How can I help you today?");
        }
    }

    void UpdateChatText(string message)
    {
        npcChatText.text = message;
    }
}
