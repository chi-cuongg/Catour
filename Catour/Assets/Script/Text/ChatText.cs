using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatText : MonoBehaviour
{
    public GameObject cat;
    public GameObject panel;
    public TextMeshProUGUI text;
    private bool isT = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Text(){
        cat.GetComponent<Controller>().enableControl(false);
        panel.SetActive(true);
        this.text.gameObject.SetActive(true);
        isT = true;
    }

    public void endText(){
        panel.SetActive(false);
        text.gameObject.SetActive(false);
        text.text = "";
        Input.ResetInputAxes();
        cat.GetComponent<Controller>().enableControl(true);
        isT = false;
    }

    public bool isText(){
        return isT;
    }
}
