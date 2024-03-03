using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class fourMyRoom : MonoBehaviour
{
    
    public GameObject Loading;
    public GameObject Loadingback;

    public InputField InputField; //사용자 이름
    public TextMeshProUGUI TextUser;

    void Start() //게임 시작 초기화
    {
        Loading.SetActive(false);
        Loadingback.SetActive(false);
        string Username = InputField.Username; 
        TextUser.text = Username;
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
