using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myroomtalk : MonoBehaviour
{
    public GameObject textbox;
    public GameObject text;

    void Start()
    {
        textbox.SetActive(false);
        text.SetActive(false);
    }
    private void OnMouseDown() 
    {
        textbox.SetActive(true);
        text.SetActive(true);
        Invoke("Talkingstop", 1.5f);
    }
    public void Talkingstop(){
        textbox.SetActive(false);
        text.SetActive(false);
    }
}
