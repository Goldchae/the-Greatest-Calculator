//�������� 3
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingStage : MonoBehaviour
{
    public GameObject BackgroundMusic;
    AudioSource backmusic;
    AudioSource audioSource;/////////////소리
    public AudioClip stagegogo;
    public AudioClip stageclear;
    public AudioClip sword;
    public AudioClip pauseclick;
    public AudioClip monappear;

    private Rankingapi rankingapi;

    void PlaySound(string action){
        switch (action){
            case "stagegogo":
                audioSource.clip = stagegogo;
                break;
            case "stageclear":
                audioSource.clip = stageclear;
                break;
            case "sword":
                audioSource.clip = sword;
                break;
            case "pauseclick":
                audioSource.clip = pauseclick;
                break;
            case "monappear":
                audioSource.clip = monappear;
                break;
        }
        audioSource.Play();
    }
    public GameObject canvas;
    public GameObject ending;
    public GameObject FightBar;
    public GameObject punch;

    public GameObject Pause;
    public GameObject Resume;
    public bool pausemode;

    public int stage; //현재 단계 확인용 변수
    public bool stagemove; //단계 사이 이동 시간 확보용 변수
    public int fortime; //시간 흐르게 하기 위한 변수



    
    float x1 = 20f;
    float x2 = 20f;
    float x3 = 20f;
    float x4 = 20f;
    float y1 = -0.8f;
    float y2 = -1.4f;
    float y3 = -0.6f;
    float y4 = -1.2f;

    //Į ���󰡱�~
    public GameObject AttackBar1;
    GameObject fly;
    float xk = -6.5f;
    float yk = 2.8f;
    public float xf;
    public float yf;
    float speed = 7.5f;
    bool flymode;

    //ŧ
    public GameObject Cul;

    public int monnum2;
    public int numnum;


    public GameObject TimeCount;
    public GameObject TimeBox;

    GameObject ForDestroy;

    private GameObject target; //마우스 클릭 확인용 변수

    void CastRay() //마우스 클릭 확인용 함수
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
    }

    public void Start() //���� ���� �ʱ�ȭ
    {
        backmusic = BackgroundMusic.GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();/////////////소리
        FightBar.SetActive(false);

        ResumeMode();

        stage = 1;
        stagemove = false;


        
        monnum2 = 0;

        
        fly = Instantiate(AttackBar1, new Vector2(xk, yk), transform.rotation);
        fly.SetActive(false);
        flymode = false;

    }

    void FixedUpdate()
    {
        if (flymode == true)
        {
            fly.transform.position = Vector2.Lerp(fly.transform.position, new Vector2(xf, yf), Time.deltaTime * speed);
            PlaySound("sword");/////////////소리
        }
        if (fly.transform.position.x >= xf - 1f && flymode == true)
        {
            Flyoff();
        }
    }

    void Update()
    {
        if (stage == 1 && stagemove == false) //난이도
        {
            fortime = 0;
            TimeCount.transform.position = new Vector2(-8.5f, TimeCount.transform.position.y);
            TimeBox.transform.position = new Vector2(-8.5f, TimeBox.transform.position.y);


            punch.GetComponent<RankingPunchScript>().punchmode = 0;
            punch.GetComponent<RankingPunchScript>().PunchMode();

            stagemove = true;
        }

        if (stage == 2 && stagemove == false) // 본게임
        {
            fortime = 1;
            TimeCount.transform.position = new Vector2(-8.5f, TimeCount.transform.position.y);
            TimeBox.transform.position = new Vector2(-8.5f, TimeBox.transform.position.y);


            punch.GetComponent<RankingPunchScript>().ScrollChange2();

            Cul.GetComponent<CulScriptRanking>().AttackBarOn();
            punch.GetComponent<RankingPunchScript>().punchmode = 1;
            punch.GetComponent<RankingPunchScript>().PunchMode();
            CulSkill2();
            stagemove = true;
        }

        if (stage == 3 && stagemove == false) //���丮 ���
        {
            fortime = 0;
            TimeCount.transform.position = new Vector2(0, TimeCount.transform.position.y);
            TimeBox.transform.position = new Vector2(0, TimeBox.transform.position.y);
            PlaySound("stageclear");/////////////
            Cul.transform.position = new Vector2(7, Cul.transform.position.y);

            punch.GetComponent<RankingPunchScript>().punchmode = 0;
            punch.GetComponent<RankingPunchScript>().PunchMode();
            punch.GetComponent<RankingPunchScript>().re();
            punch.GetComponent<RankingPunchScript>().ScrollChange3();
            Cul.GetComponent<CulScriptRanking>().AttackBarOff();
     
            Invoke("WinAni", 1f);

            stagemove = true;
        }

        if (stage == 3 ) //Ŭ����
        {
            PlaySound("stagegogo");/////////////소리
            StageEnding();

            stagemove = true;
        }
    }

    public void PauseMode()
    {
        Time.timeScale = 0;
        pausemode = true;
        Pause.SetActive(false);
        Resume.SetActive(true);
    }
    public void MusicPauseMode()//음악도 같이
    {
        backmusic.Pause();
        Time.timeScale = 0;
        pausemode = true;
        //GameObject.Find("buttonclick").GetComponent<Buttonclick2>().pausemode = true;
        Pause.SetActive(false);
        Resume.SetActive(true);
    }
    public void ResumeMode()
    {
        Time.timeScale = 1;
        pausemode = false;
        Pause.SetActive(true);
        Resume.SetActive(false);
    }
    public void MusicResumeMode() //음악도 같이
    {
        backmusic.Play();
        Time.timeScale = 1;
        pausemode = false;
        //GameObject.Find("buttonclick").GetComponent<Buttonclick2>().pausemode = false;
        Pause.SetActive(true);
        Resume.SetActive(false);
    }



    public void Fly()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("attack");
        GameObject.Find("Player").GetComponent<KalScript>().AttackEffect();
        fly.SetActive(true);
        flymode = true;

        float r1 = Mathf.Atan2(yf - yk, xf - xk) * Mathf.Rad2Deg;
        if (r1 < -30)
        {
            r1 = -30;
        }
        fly.transform.rotation = Quaternion.Euler(0, 0, r1);
    }
    public void Flyoff()
    {

            if(numnum == 1)
            {
                GameObject.Find("NumberBundle").GetComponent<RankingNumberBundleScript>().num1setting();
            }
            else if (numnum == 2)
            {
                GameObject.Find("NumberBundle").GetComponent<RankingNumberBundleScript>().num2setting();
            }
            else if (numnum == 3)
            {
                GameObject.Find("NumberBundle").GetComponent<RankingNumberBundleScript>().num3setting();
            }
            else if (numnum == 4)
            {
                GameObject.Find("NumberBundle").GetComponent<RankingNumberBundleScript>().num4setting();
            }
            else if (numnum == 5)
            {
                GameObject.Find("NumberBundle").GetComponent<RankingNumberBundleScript>().num5setting();
            }

 

        fly.transform.position = new Vector2(xk, yk);
        fly.transform.Rotate(0, 0, 0);
        fly.SetActive(false);
        flymode = false;
        punch.GetComponent<RankingPunchScript>().punchmode = 1;
        punch.GetComponent<RankingPunchScript>().PunchMode();
        punch.GetComponent<RankingPunchScript>().ScrollChange2();
    }
    public void realFlyoff()
    {
        fly.SetActive(false);
        flymode = false;
    }

    public void CulSkill2()
    {
        GameObject.Find("NumberBundle").GetComponent<RankingNumberBundleScript>().numbunOn();
        GameObject.Find("Cul").GetComponent<CulScriptRanking>().Timer();
        FightBar.SetActive(true);
        fortime = 1;
    }

    public void Win()
    {
        FightBar.SetActive(false);
        GameObject.Find("NumberBundle").GetComponent<RankingNumberBundleScript>().numbunOff();
        rankingapi.UpdateScore("arduinocc04", 100); /////////

        Invoke("WinAni", 1f);
    }
    void WinAni()
    {
        Cul.GetComponent<Animator>().SetTrigger("hit");
    }

    public void Lose()
    {
        punch.GetComponent<RankingPunchScript>().punchmode = 0;
        punch.GetComponent<RankingPunchScript>().PunchMode();
        punch.GetComponent<RankingPunchScript>().re();
        punch.GetComponent<RankingPunchScript>().ScrollChange3();
        FightBar.SetActive(false);
        Cul.GetComponent<CulScriptRanking>().AttackBarOff();
        Cul.GetComponent<CulScriptRanking>().move2();
        rankingapi.UpdateScore("arduinocc04", -100);
        Invoke("LoseAni", 1f);
    }
    void LoseAni()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hit");
        GameObject.Find("ending").GetComponent<endingscene>().Playerpowerend();
    }
    public void TimeOut()
    {
        punch.GetComponent<RankingPunchScript>().punchmode = 0;
        punch.GetComponent<RankingPunchScript>().PunchMode();
        punch.GetComponent<RankingPunchScript>().re();
        punch.GetComponent<RankingPunchScript>().ScrollChange3();
        FightBar.SetActive(false);
        GameObject.Find("NumberBundle").GetComponent<RankingNumberBundleScript>().numbunOff();
        Cul.GetComponent<CulScriptRanking>().AttackBarOff();
        Invoke("TimeLoseAni", 1f);
    }
    void TimeLoseAni()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("hit");
        GameObject.Find("ending").GetComponent<endingscene>().Stagetimeout();
    }


    public void StageEnding()
    {
        if (ending != null)
        {
            ending.GetComponent<endingscene>().stage = 3;
            ending.GetComponent<endingscene>().endingStart();
        }
    }
}