using UnityEngine;

public class NPCChatManager : MonoBehaviour
{
    public GameObject npcChatPanel;  // Panel chứa nội dung chat
    public GameObject[] chatTexts;  // Mảng chứa các Text component

    private int currentTextIndex = 0;
    public bool triggered = false;
    public GameObject cat;

    void Start()
    {
        if (npcChatPanel == null)
        {
            Debug.LogError("NPC Chat Panel is not assigned in the inspector.");
            return;
        }

        if (chatTexts == null || chatTexts.Length == 0)
        {
            Debug.LogError("Chat Texts are not assigned in the inspector.");
            return;
        }

        // Ẩn khung chat và tất cả các Text khi bắt đầu
        npcChatPanel.SetActive(false);
        HideAllTexts();
    }

    void Update()
    {
        if (triggered)
        {
            if (cat.GetComponent<Controller>().isControl())
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ToggleChat();
                    cat.GetComponent<Controller>().enableControl(false);
                }
            }
        }

        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     ToggleChat();
        // }

        if (npcChatPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextText();
        }
    }

    void ToggleChat()
    {
        npcChatPanel.SetActive(true);
        ShowNextText();  // Hiển thị đoạn chat đầu tiên khi mở khung chat
    }

    void ShowNextText()
    {
        HideAllTexts();  // Ẩn tất cả các Text hiện tại

        if (currentTextIndex < chatTexts.Length)
        {
            chatTexts[currentTextIndex].SetActive(true);  // Hiển thị Text tiếp theo
            currentTextIndex++;
        }
        else
        {
            // Nếu đã đến đoạn chat cuối cùng, có thể đóng khung chat hoặc lặp lại từ đầu
            npcChatPanel.SetActive(false);
            currentTextIndex = 0;  // Hoặc thiết lập lại về 0 nếu muốn lặp lại
            cat.GetComponent<Controller>().enableControl(true);
        }
    }

    void HideAllTexts()
    {
        foreach (GameObject text in chatTexts)
        {
            text.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        triggered = true;
        cat = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
        cat = null;
    }
}
