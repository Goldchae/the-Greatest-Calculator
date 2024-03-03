using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MySetting : MonoBehaviour
{
    
    public GameObject Loading;
    public GameObject Loadingback;

    void Start() //게임 시작 초기화
    {
        Loading.SetActive(false);
        Loadingback.SetActive(false);
    }

    public void Loadingblack()
    {
        Loading.SetActive(true);
        Loadingback.SetActive(true);
        Invoke("Loadingblackstop", 0.8f);
    }
    
    public void Loadingblackstop(){
        Loading.SetActive(false);
        Loadingback.SetActive(false);
    }
}
