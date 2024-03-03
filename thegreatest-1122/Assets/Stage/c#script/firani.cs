using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firani : MonoBehaviour
{

    public Image tutorialImage; //왕
    public Sprite TestSprite1;// //왕
    public Sprite TestSprite2;// 기사단
    public Sprite TestSprite3;//케르원기
    public Sprite TestSprite4;//없어짐
    public Sprite TestSprite5;//망가진마을
    public Sprite TestSprite6;// 왕

    int tuNum = 1;

    public void gotutorial(){
        if (tuNum == 1){
            tutorialImage.sprite = TestSprite1;
            tuNum += 1;
        }else if (tuNum == 2){
            tutorialImage.sprite = TestSprite2;
            tuNum += 1;
        }else if (tuNum == 3){
            tutorialImage.sprite = TestSprite3;
            tuNum += 1;
        }else if (tuNum == 4){
            tutorialImage.sprite = TestSprite4;
            tuNum += 1;
        }else if (tuNum == 5){
            tutorialImage.sprite = TestSprite5;
            tuNum += 1;
        }else if (tuNum == 6){
            tutorialImage.sprite = TestSprite6;
            tuNum += 1;
        }else {
        }
    }
}
