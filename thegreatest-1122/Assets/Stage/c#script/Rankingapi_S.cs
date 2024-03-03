using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Rankingapi_S : MonoBehaviour
{
    //사용자 점수요구
    public Rankingapi scRankingapi;
    public InputField InputField;

    void Awake()
    {
        NativeLeakDetection.Mode = NativeLeakDetectionMode.EnabledWithStackTrace;
        scRankingapi.Numbers = 3;
        string Username = InputField.Username; 
        scRankingapi.OnRequest_Api_Ranking_List(Username); 
    }

        // 점수 보내기 - 1
        //OnRequest_Api_Ranking_Req("정람쥐", 1);

        //랭킹 전체 리스트 받기 - 2
        //OnRequest_Api_Ranking_List(""); 

        //사용자 점수요구 - 3
        //OnRequest_Api_Ranking_List("정람쥐"); 
}
