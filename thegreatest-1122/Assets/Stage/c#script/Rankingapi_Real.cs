using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Rankingapi_Real : MonoBehaviour
{
    public Rankingapi scRankingapi;

    public TextMeshProUGUI TextUser1; //32
    public TextMeshProUGUI TextScore1;
    public TextMeshProUGUI TextUser2; 
    public TextMeshProUGUI TextScore2;
    public TextMeshProUGUI TextUser3; 
    public TextMeshProUGUI TextScore3;
    public TextMeshProUGUI TextUser4; 
    public TextMeshProUGUI TextScore4;
    public TextMeshProUGUI TextUser5; 
    public TextMeshProUGUI TextScore5;
    public TextMeshProUGUI TextUser6; 
    public TextMeshProUGUI TextScore6;
    public TextMeshProUGUI TextUser7; 
    public TextMeshProUGUI TextScore7;
    public TextMeshProUGUI TextUser8; 
    public TextMeshProUGUI TextScore8;
    public TextMeshProUGUI TextUser9; 
    public TextMeshProUGUI TextScore9;
    public TextMeshProUGUI TextUser10; 
    public TextMeshProUGUI TextScore10;
    public TextMeshProUGUI TextUser11; 
    public TextMeshProUGUI TextScore11;
    public TextMeshProUGUI TextUser12; 
    public TextMeshProUGUI TextScore12;
    public TextMeshProUGUI TextUser13; 
    public TextMeshProUGUI TextScore13;
    public TextMeshProUGUI TextUser14; 
    public TextMeshProUGUI TextScore14;
    public TextMeshProUGUI TextUser15; 
    public TextMeshProUGUI TextScore15;
    public TextMeshProUGUI TextUser16; 
    public TextMeshProUGUI TextScore16;
    public TextMeshProUGUI TextUser17; 
    public TextMeshProUGUI TextScore17;
    public TextMeshProUGUI TextUser18; 
    public TextMeshProUGUI TextScore18;
    public TextMeshProUGUI TextUser19; 
    public TextMeshProUGUI TextScore19;
    public TextMeshProUGUI TextUser20; 
    public TextMeshProUGUI TextScore20;
    public TextMeshProUGUI TextUser21; 
    public TextMeshProUGUI TextScore21;
    public TextMeshProUGUI TextUser22; 
    public TextMeshProUGUI TextScore22;
    public TextMeshProUGUI TextUser23; 
    public TextMeshProUGUI TextScore23;
    public TextMeshProUGUI TextUser24; 
    public TextMeshProUGUI TextScore24;
    public TextMeshProUGUI TextUser25; 
    public TextMeshProUGUI TextScore25;
    public TextMeshProUGUI TextUser26; 
    public TextMeshProUGUI TextScore26;
    public TextMeshProUGUI TextUser27; 
    public TextMeshProUGUI TextScore27;
    public TextMeshProUGUI TextUser28; 
    public TextMeshProUGUI TextScore28;
    public TextMeshProUGUI TextUser29; 
    public TextMeshProUGUI TextScore29;
    public TextMeshProUGUI TextUser30; 
    public TextMeshProUGUI TextScore30;
    public TextMeshProUGUI TextUser31; 
    public TextMeshProUGUI TextScore31;
    public TextMeshProUGUI TextUser32; 
    public TextMeshProUGUI TextScore32;

    void Start()
    {
        scRankingapi.OnRequest_Api_Ranking_List(""); 

        Invoke("ranking",0.1f);
    }
    public void ranking(){
        string[] onelistSplit = scRankingapi.onelistSplit;
        int RankLen = onelistSplit.Length;

        for( int i=0 ; i <= (RankLen-1) ; i++){
            string[] Ranking = onelistSplit[i].Split("\"");
            string user = Ranking[3];
            string scores = Ranking[6];
            string score = scores.Replace(":", "");
            if (i == 0){
                TextUser1.text = user; //유저찍기
                TextScore1.text = score; //점수찍기
            }else if (i == 1){
                TextUser2.text = user; 
                TextScore2.text = score; 
            }else if (i == 2){
                TextUser3.text = user; 
                TextScore3.text = score; 
            }else if (i == 3){
                TextUser4.text = user; 
                TextScore4.text = score; 
            }else if (i == 4){
                TextUser5.text = user; 
                TextScore5.text = score; 
            }else if (i == 5){
                TextUser6.text = user; 
                TextScore6.text = score; 
            }else if (i == 6){
                TextUser7.text = user; 
                TextScore7.text = score; 
            }else if (i == 7){
                TextUser8.text = user; 
                TextScore8.text = score; 
            }else if (i == 8){
                TextUser9.text = user; 
                TextScore9.text = score; 
            }else if (i == 9){
                TextUser10.text = user; 
                TextScore10.text = score; 
            }
            else if (i == 10){
                TextUser11.text = user; 
                TextScore11.text = score; 
            }else if (i == 11){
                TextUser12.text = user; 
                TextScore12.text = score; 
            }else if (i == 12){
                TextUser13.text = user; 
                TextScore13.text = score; 
            }else if (i == 13){
                TextUser14.text = user; 
                TextScore14.text = score; 
            }else if (i == 14){
                TextUser15.text = user; 
                TextScore15.text = score; 
            }else if (i == 15){
                TextUser16.text = user; 
                TextScore16.text = score; 
            }else if (i == 16){
                TextUser17.text = user; 
                TextScore17.text = score; 
            }else if (i == 17){
                TextUser18.text = user; 
                TextScore18.text = score; 
            }else if (i == 18){
                TextUser19.text = user; 
                TextScore19.text = score; 
            }else if (i == 19){
                TextUser20.text = user; 
                TextScore20.text = score; 
            }else if (i == 20){
                TextUser21.text = user; 
                TextScore21.text = score; 
            }else if (i == 21){
                TextUser22.text = user; 
                TextScore22.text = score; 
            }else if (i == 22){
                TextUser23.text = user; 
                TextScore23.text = score; 
            }else if (i == 23){
                TextUser24.text = user; 
                TextScore24.text = score; 
            }else if (i == 24){
                TextUser25.text = user; 
                TextScore25.text = score; 
            }else if (i == 25){
                TextUser26.text = user; 
                TextScore26.text = score; 
            }else if (i == 26){
                TextUser27.text = user; 
                TextScore27.text = score; 
            }else if (i == 27){
                TextUser28.text = user; 
                TextScore28.text = score; 
            }else if (i == 28){
                TextUser29.text = user; 
                TextScore29.text = score; 
            }else if (i == 29){
                TextUser30.text = user; 
                TextScore30.text = score; 
            }else if (i == 30){
                TextUser31.text = user; 
                TextScore31.text = score; 
            }else if (i == 31){
                TextUser32.text = user; 
                TextScore32.text = score; 
            }else{
            
            }
        }
    }

}
