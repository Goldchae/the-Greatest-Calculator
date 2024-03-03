using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankpageClick : MonoBehaviour
{
    public GameObject Month;
    public GameObject Monthtext;


    void Start() //게임 시작 초기화
    {
        Month.SetActive(false);
        Monthtext.SetActive(false);
    }
    private void OnMouseDown() 
    {
        Month.SetActive(true);
        Monthtext.SetActive(true);
    }
}
