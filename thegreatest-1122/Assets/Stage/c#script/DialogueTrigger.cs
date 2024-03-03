using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;
    public GameObject textbox;
    public GameObject rolling;

    void Start()
    {
        textbox.SetActive(false);
    }
    public void textboxclick(){
        textbox.SetActive(true);
        rolling.SetActive(false);
    }
    public void Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);
    }
}
