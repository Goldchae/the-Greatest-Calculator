using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalk : MonoBehaviour
{
    public GameObject Talk;
    public GameObject Talktext;

    void Start() //게임 시작 초기화
    {
        Talk.SetActive(false);
        Talktext.SetActive(false);
    }
    private void OnMouseDown() 
    {
       Talk.SetActive(true);
        Talktext.SetActive(true);
        Invoke("Talkingstop", 1f);
    }
    
    public void Talkingstop(){
        Talk.SetActive(false);
        Talktext.SetActive(false);
    }
}
