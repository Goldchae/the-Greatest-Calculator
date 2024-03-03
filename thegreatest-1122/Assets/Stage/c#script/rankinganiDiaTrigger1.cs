using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankinganiDiaTrigger1 : MonoBehaviour
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
        Debug.Log("ggg");
        rolling.SetActive(false);
    }
    public void Trigger()
    {
        var system = FindObjectOfType<rankinganiDia>();
        system.Begin(info);
    }
}
