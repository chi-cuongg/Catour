using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fish(Sprite sprite){
        gameObject.GetComponent<Image>().sprite = sprite;
        this.gameObject.SetActive(true);
    }
}
