using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private Text bottomText;
    void Start()
    {
        bottomText = GetComponent<Text>();
    }

    // Update is called once per frame
    void showText(string message){
        bottomText.text = message;
        bottomText.gameObject.SetActive(true);
    }

    void hideText(){
        bottomText.text = " ";
        bottomText.gameObject.SetActive(false);
    }
}
