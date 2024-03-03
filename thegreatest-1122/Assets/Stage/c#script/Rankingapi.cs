using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class Rankingapi : MonoBehaviour
{
    public string[] onelistSplit;
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI TextUser;
    public int Numbers = 2;


    // 요청 : Ranking Req     
    public class ReqScoreRanking
    {
        public string userId;
        public int score;
    }

    public ReqScoreRanking cReqScoreRanking = null;

    [System.Serializable]
    public class ResRanking_Data
    {
        public string userId;
        public int score;
    }

    [System.Serializable]
    public class ResRanking_List
    {
        public List<ResRanking_Data> ranking;
    }

    public ResRanking_List cResRanking_List = null;

    protected string strError;

    // 랭킹등록
    public void OnRequest_Api_Ranking_Req(string userId, int score)
    {        
       StartCoroutine(Send_Api_Ranking_Req(userId, score));
    }

    // 랭킹조회 OnRequest_Api_Ranking_Req
    public void OnRequest_Api_Ranking_List(string userId)
    {        
       StartCoroutine(Send_Api_Ranking_List(userId));
    }

    // 요청 상태 체크
    public int CheckState_Request()
    {
        return nState_Request;
    }

    protected int nState_Request= 10; // 서버 요청 상태(0: 전송   1: 전송 성공   -1: 전송 실패   -2: 결과 파씽 에러)   

    // ranking req
    protected IEnumerator Send_Api_Ranking_Req(string userId, int score)
    {
        ReqScoreRanking request = new ReqScoreRanking();
        request.userId = userId;
        request.score = score;

        string strBody = JsonUtility.ToJson(request);

        string url = "http://ec2-13-125-213-205.ap-northeast-2.compute.amazonaws.com:8080/api/v1/score/userinfo";

        using (UnityWebRequest uwr = UnityWebRequest.Post(url, string.Empty))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(strBody);
            uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            
            nState_Request = 0;
            yield return uwr.SendWebRequest();
                        
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                nState_Request = -1;
                strError = uwr.downloadHandler.text;
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);  
                nState_Request = 1;
            }
            uwr.Dispose();
        }
    }

    // Ranking List
    protected IEnumerator Send_Api_Ranking_List(string userId)
    {
        ReqScoreRanking request = new ReqScoreRanking();
        request.userId = userId;
        request.score = 0;

        string strBody = JsonUtility.ToJson(request);

        string url = "http://ec2-13-125-213-205.ap-northeast-2.compute.amazonaws.com:8080/api/v1/list/userinfo";

        using (UnityWebRequest uwr = UnityWebRequest.Post(url, string.Empty))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(strBody);
            uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");

            nState_Request = 0;
            // Debug.Log(strBody);  // {"userId":"aaa","score":0}
            yield return uwr.SendWebRequest();
                        
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                nState_Request = -1;
                strError = uwr.downloadHandler.text;
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);//"ranking":[{"userId":"aaa","score":10},...
                string OneList = uwr.downloadHandler.text;
                string oneList = OneList.Replace("{\"ranking\":[{", "");
                string onelist = oneList.Replace("}]}", "");

                if (Numbers == 2){
                    onelistSplit = onelist.Split("},{");
                }else{
                    string[] onelistSplit = onelist.Split(",");
                    string calUser = onelistSplit[0];
                    string[] calUserSplit = calUser.Split(":");

                    string calscore = onelistSplit[1];
                    string[] calscoreSplit = calscore.Split(":");

                    Debug.Log(calUserSplit[1]);
                    Debug.Log(calscoreSplit[1]);
                    TextUser.text = calUserSplit[1]; //유저찍기
                    TextScore.text = calscoreSplit[1]; //점수찍기
                }

                try
                {
                    cResRanking_List = JsonUtility.FromJson<ResRanking_List>(uwr.downloadHandler.text);
                    nState_Request = 1;
                }
                catch (Exception _e)
                {
                    nState_Request = -2;
                    Debug.Log(_e.Message);
                }
            }
            uwr.Dispose();
        }
    }
}

// 주소   http://43.201.111.31:8080/swagger-ui.html