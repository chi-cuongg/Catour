using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatText : MonoBehaviour
{
    public GameObject cat;
    public GameObject panel;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Text(string text){
        cat.GetComponent<Controller>().enableControl(false);
        panel.SetActive(true);
        this.text.gameObject.SetActive(true);
        this.text.text = text;
    }

    public void endText(){
        panel.SetActive(false);
        text.gameObject.SetActive(false);
        text.text = "";
        Input.ResetInputAxes();
        cat.GetComponent<Controller>().enableControl(true);
    }
}
