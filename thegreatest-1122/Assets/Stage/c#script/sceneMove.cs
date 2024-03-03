using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneMove : MonoBehaviour
{
    
    public void SceneChange(){ // 랭킹
        SceneManager.LoadScene("RankingFight");
    }
    public void SceneChange2(){
        SceneManager.LoadScene("RealRanking");
    }
    public void SceneChange3(){
        SceneManager.LoadScene("RankingHome");
    }
    public void SceneChange0(){
        SceneManager.LoadScene("Rankingani");
    }

    public void SceneChangechahom(){// 캐릭터
        SceneManager.LoadScene("4.1 character");
    }
    public void SceneChangecha0(){
        SceneManager.LoadScene("4.1.0 cha");
    }public void SceneChangecha1(){
        SceneManager.LoadScene("4.1.1 cha");
    }public void SceneChangecha2(){
        SceneManager.LoadScene("4.1.2 cha");
    }public void SceneChangecha3(){
        SceneManager.LoadScene("4.1.3 cha");
    }public void SceneChangecha4(){
        SceneManager.LoadScene("4.1.4 cha");
    }public void SceneChangecha5(){
        SceneManager.LoadScene("4.1.5 cha");
    }public void SceneChangecha6(){
        SceneManager.LoadScene("4.1.6 cha");
    }public void SceneChangecha7(){
        SceneManager.LoadScene("4.1.7 cha");
    }public void SceneChangecha8(){
        SceneManager.LoadScene("4.1.8 cha");
    }
    public void SceneChangecha9(){
        SceneManager.LoadScene("4.1.9 cha");
    }

    public void SceneChangeMyroom(){ //마이룸
        SceneManager.LoadScene("4 my_room");
    } 
    public void SceneChangeMyroomSetting(){ //설정
        SceneManager.LoadScene("4.2 Settings");
    }

    public void SceneChangename(){ // 이름입력
        SceneManager.LoadScene("2 playername");
    }
    public void SceneChangefirani(){ // 왕애니
        SceneManager.LoadScene("3 Startani");
    }

    public void SceneChangestageHome(){ // 스테이지홈
        SceneManager.LoadScene("Stagehome");
    }

    public void SceneChangestage1(){ // 스테이지1
        SceneManager.LoadScene("Stage 1");
    }public void SceneChangestage2(){ // 플톡2
        SceneManager.LoadScene("go_stage2");
    }
    public void SceneChangestage3(){ // 플톡3
        SceneManager.LoadScene("go_stage3");
    }

    private bool pauseOn = false;
    public Image pausebutton; 
    public Sprite pause2; 
    public Sprite gogo2;
    private bool pauseimage = true;

    public void ActivePause(){
        if(!pauseOn){
            realstop();
        }
        else{
            realgo();
        }
        pauseOn = !pauseOn;
    }
    public void ChangeImage()
    {
        if(pauseimage){
             pausebutton.sprite = gogo2;
        }
        else{
            pausebutton.sprite = pause2;
        }
        pauseimage = !pauseimage;
    }
    public GameObject BackgroundMusic;
    AudioSource backmusic;
    public void Start() //게임 시작 초기화
    {
        //backmusic = BackgroundMusic.GetComponent<AudioSource>();
    }
    void realstop(){
        Time.timeScale = 0;
        //backmusic.Pause();
    }
    void realgo(){
        Time.timeScale = 1;
        //backmusic.Play();
    }

    
}
