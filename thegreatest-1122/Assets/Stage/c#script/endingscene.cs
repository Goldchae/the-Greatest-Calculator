// 스테이지의 엔딩씬. 별/플레이어 불러오기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingscene : MonoBehaviour
{   
    private GameObject endingback, endingPlayer, endingstar1, endingstar2, endingstar3, endingfailstar2, endingfailstar3;
    public GameObject Zero, canvas, Timeover, TimeCount, TimeEndingbox, Power;

    public GameObject a, b, c, d, e, f, g, h, I;

    float time;
    int star;
    public int stage;
    public GameObject BackgroundMusic;
    AudioSource backmusic;

    public bool ending;
    public int endingnum;

    //시간 불러오기 

    public void Start() //게임 시작 초기화
    {
        backmusic = BackgroundMusic.GetComponent<AudioSource>();
        ending = false;
        endingnum = 0;
    }

    public void endingStart()
    {
        backmusic.Pause();
        ending = true;
        endingnum = 1;
        if (stage == 1)
        {
            time = TimeCount.GetComponent<Timecount>().countdownSeconds;
            GameObject.Find("buttonclick").GetComponent<Buttonclick>().pausemode = true;
        }
        else if (stage == 2)
        {
            time = TimeCount.GetComponent<Timecount2>().countdownSeconds;
            GameObject.Find("buttonclick").GetComponent<Buttonclick2>().pausemode = true;
        }
        else if (stage == 3)
        {
            time = TimeCount.GetComponent<Timecount3>().countdownSeconds;
            GameObject.Find("buttonclick").GetComponent<Buttonclick>().pausemode = true;
        }

        if (30 >= time && time > 0)
        {
            star = 1;
        }
        else if (60 >= time && time > 30) 
        {
            star = 2;
        }
        else if (time > 60)
        {
            star = 3;
        }

        if (star == 1){//별 1개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-4.54f,1.12f, -5f), endingstar1.transform.rotation); // 별 생성
            //빈 2.3번째 별 
            endingfailstar2 = Resources.Load<GameObject>("ending/realendingfailstar2");
            Instantiate(endingfailstar2, new Vector3(0,3, -5f),endingfailstar2.transform.rotation);
            endingfailstar3 = Resources.Load<GameObject>("ending/realendingfailstar3");
            Instantiate(endingfailstar3, new Vector3(5,1.5f, -5f), endingfailstar3.transform.rotation);
        }
        else if (star == 2)
        {//별 2개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-4.54f,1.12f, -5f), endingstar1.transform.rotation); // 별 생성
            endingstar2 = Resources.Load<GameObject>("ending/realendingstar2");
            Instantiate(endingstar2, new Vector3(0,3, -5f), Quaternion.identity);
            //빈 3번째 별 추가하기
            endingfailstar3 = Resources.Load<GameObject>("ending/realendingfailstar3");
            Instantiate(endingfailstar3, new Vector3(5,1.5f, -5f), endingfailstar3.transform.rotation);

        }
        else{//별 3개
            endingback = Resources.Load<GameObject>("ending/endingBackground");
            Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
            endingPlayer = Resources.Load<GameObject>("ending/realendingplayer");
            Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
            endingstar1 = Resources.Load<GameObject>("ending/realendingstar1");
            Instantiate(endingstar1, new Vector3(-5,1.5f, -5f), endingstar1.transform.rotation); // 별 생성
            endingstar2 = Resources.Load<GameObject>("ending/realendingstar2");
            Instantiate(endingstar2, new Vector3(0,3, -5f), Quaternion.identity);
            endingstar3 = Resources.Load<GameObject>("ending/realendingstar3");
            Instantiate(endingstar3, new Vector3(5,1.5f, -5f), endingstar3.transform.rotation);
        }
    }
    public void Stagetimeout()
    {
        ending = true;
        backmusic.Pause();
        endingnum = 2;
        endingback = Resources.Load<GameObject>("ending/endingBackground");
        Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
        endingPlayer = Resources.Load<GameObject>("ending/timeendingplayer1");
        Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
        canvas.GetComponent<TextScript2>().endingtext1.fontSize = 1.5f;
        canvas.GetComponent<TextScript2>().endingtext2.fontSize = 1.5f;

        Instantiate(TimeEndingbox, new Vector3(3.75f, -0.3f, -4f), Quaternion.identity);

        TimeCount.SetActive(false);  
        Power.SetActive(false);

        a.SetActive(false); b.SetActive(false); c.SetActive(false); d.SetActive(false); e.SetActive(false); f.SetActive(false); g.SetActive(false); h.SetActive(false); I.SetActive(false);

        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText(){
        while (true) {
            Zero.SetActive(false);    
            yield return new WaitForSeconds (0.4f);
            Zero.SetActive(true);    
            yield return new WaitForSeconds (0.4f);
        }
    }  

    public void Playerpowerend(){
        ending = true;
        backmusic.Pause();
        endingnum = 3;
        GameObject.Find("Player").GetComponent<Animator>().SetBool("ouch", true);
        endingback = Resources.Load<GameObject>("ending/endingBackground");
        Instantiate(endingback, new Vector3(-0.08f,-0.02f,-3f), Quaternion.identity); // 배경이미지 생성
        endingPlayer = Resources.Load<GameObject>("ending/timeendingplayer1");
        Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-5f), Quaternion.identity); //주인공이미지생성
        canvas.GetComponent<TextScript2>().endingtext1.text = "Power";
        canvas.GetComponent<TextScript2>().endingtext2.text = "0";
        canvas.GetComponent<TextScript2>().endingtext1.fontSize = 1.5f;
        canvas.GetComponent<TextScript2>().endingtext2.fontSize = 1.5f;

        Instantiate(TimeEndingbox, new Vector3(3.75f, -0.3f, -4f), Quaternion.identity);

        TimeCount.SetActive(false);
        Power.SetActive(false);

        a.SetActive(false); b.SetActive(false); c.SetActive(false); d.SetActive(false); e.SetActive(false); f.SetActive(false); g.SetActive(false); h.SetActive(false); I.SetActive(false);

        StartCoroutine(BlinkText());
    }
}
  
  