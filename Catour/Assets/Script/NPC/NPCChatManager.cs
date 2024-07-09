using UnityEngine;

public class NPCChatManager : MonoBehaviour
{
    public GameObject npcChatPanel;  // Panel chứa nội dung chat
    public GameObject[] chatTexts;  // Mảng chứa các Text component
    public GameObject endText;
    private bool end = false;
    private int currentTextIndex = 0;
    private bool triggered = false;
    private GameObject cat;
    private SceneChange scene;
    public bool change = true;
    public string minigame;
    void Start()
    {
        // Ẩn khung chat và tất cả các Text khi bắt đầu
        npcChatPanel.SetActive(false);
        HideAllTexts();
    }

    void Update()
    {
        if (npcChatPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Input.ResetInputAxes();
            ShowNextText();
        }
        
        if (triggered)
        {
            if (cat.GetComponent<Controller>().isControl())
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    cat.GetComponent<Controller>().enableControl(false);
                    ToggleChat();
                }
            }
        }
    }

    void ToggleChat()
    {
        npcChatPanel.SetActive(true);
        ShowNextText();  // Hiển thị đoạn chat đầu tiên khi mở khung chat
    }

    void ShowNextText()
    {
        if((scene.getKey() < scene.Require()) || !change){
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

                if(scene != null && change){ 
                    this.enabled = false;
                    scene.MiniGame(minigame, this.gameObject);
                }
            }
        }else{
            if(!end){ 
                if(endText != null) endText.SetActive(true);
                end = true;
            }else{
                endText.SetActive(false);
                npcChatPanel.SetActive(false);
                cat.GetComponent<Controller>().enableControl(true);
                end = false;
            }
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
        scene = FindAnyObjectByType<SceneChange>();

        triggered = true;
        cat = other.gameObject;
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
        cat = null;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
