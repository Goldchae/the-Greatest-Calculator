using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story3Script : MonoBehaviour
{
    public GameObject background, playerimage, bossimage, textbox, nextbutton, canvas;
    GameObject background1, playerimage1, bossimage1, textbox1, nextbutton1;

    public Text storytext;

    public List<string> sentences1;
    public List<string> sentences1_2;
    public List<string> sentences2;
    public List<string> sentences2_2;
    public List<string> sentences3;
    public List<string> sentences3_1;
    public List<string> sentences3_15;
    public List<string> sentences3_2;
    public List<string> sentences4;
    public List<string> sentences4_2;
    public List<string> sentences5;
    public bool clickNextButton = false;

    int size, i, s;

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

    void Start()
    {
        background1 = Instantiate(background, background.transform.position, transform.rotation);
        playerimage1 = Instantiate(playerimage, playerimage.transform.position, transform.rotation);
        bossimage1 = Instantiate(bossimage, bossimage.transform.position, transform.rotation);
        textbox1 = Instantiate(textbox, textbox.transform.position, transform.rotation);
        nextbutton1 = Instantiate(nextbutton, nextbutton.transform.position, transform.rotation);

        canvas.SetActive(false);
        background1.SetActive(false);
        playerimage1.SetActive(false);
        bossimage1.SetActive(false);
        textbox1.SetActive(false);
        nextbutton1.SetActive(false);
    }

    void Update()
    {
        if (clickNextButton == true && GameObject.Find("Stage").GetComponent<Stage3>().story != 0)
        {
            i++;
            if (i == size)
            {
                StoryOff();
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 1)
            {
                if (i == 1 || i == 2 || i == 4 || i == 5 || i == 8 || i == 9 || i == 10)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 1.5f)
            {
                storytext.text = sentences1_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 2)
            {
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 9 || i == 11)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 2.5)
            {
                if (i == 1 || i == 3)
                {
                    if (i == 1)
                    {
                        s = 11;
                        SpriteChange();
                    }
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences2_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 3)
            {
                if (i == 1 || i == 2)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences3[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 3.1)
            {
                storytext.text = sentences3_1[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 3.15)
            {
                storytext.text = sentences3_15[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 3.5)
            {
                storytext.text = sentences3_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 4)
            {
                storytext.text = sentences4[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 4.5)
            {
                if (i == 1 || i == 2 || i == 3)
                {
                    Storycul();
                }
                else
                {
                    Storykal();
                }
                storytext.text = sentences4_2[i];
                clickNextButton = false;
            }
            else if (GameObject.Find("Stage").GetComponent<Stage3>().story == 5)
            {
                storytext.text = sentences5[i];
                clickNextButton = false;
            }
        }
    }

    public void Story1On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 1;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1 = new List<string>();
        //1, 2, 4, 5, 8, 9, 10
        sentences1.Add("...오랜만이야, 큘."); //칼
        sentences1.Add("그래... 정말 오랜만이다. 넌 역시 하나도 변한 게 없어."); //큘
        sentences1.Add("그때나 지금이나 아득바득 나를 방해하는구나!"); //큘
        sentences1.Add("너만을 위한 기사단을 만들었던데."); //칼
        sentences1.Add("다 내 신념에 반한 자들이지. 같잖은 정의나 추구하는 너희 왕국의 기사들하곤 차원이 달라."); //큘
        sentences1.Add("우린 훨씬 큰 목표! 훨씬 큰 세상을 다스릴 생각이지!"); //큘
        sentences1.Add("이제 그만 멈춰. 지금이라도 다시 내 친구 큘로 돌아와."); //칼
        sentences1.Add("당장 케르원기를 돌려줘. 더 이상 네가 만들어낸 괴물들로 세상을 괴롭히지 마!!!"); //칼
        sentences1.Add("아니! 적어도 나에겐 이들이 진짜 기사고 너희 계산기사단들이 나를 괴롭히는 괴물들이었어!"); //큘
        sentences1.Add("내 검술 실력은 누구보다 출중했어. 떨어질 리 없었다!"); //큘
        sentences1.Add("기필코 이번엔 너를 무너뜨려주마!"); //큘
        sentences1.Add("어쩔 수 없지. 그때나 지금이나, 네 마음대로 되는 건 없을 거야!"); //칼
        size = sentences1.Count;

        s = 0;
        SpriteChange();
        s = 11;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences1[i];
    }
    public void Story1_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 1.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences1_2 = new List<string>();
        sentences1_2.Add("가라! 나의 기사들이여!"); //큘
        size = sentences1_2.Count;

        s = 0;
        SpriteChange();
        s = 6;
        SpriteChange();
        Storycul();
        i = 0;
        storytext.text = sentences1_2[i];
    }

    public void Story2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 2;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2 = new List<string>();
        //1, 3, 5, 7, 9, 11
        sentences2.Add("큘, 이런 자잘한 괴물들론 넌 날 절대 무너뜨릴 수 없어!"); //칼
        sentences2.Add("하! 과연 그럴까? 네 콧대를 꺾기 위헤 이번엔 끔찍한 수로 몰려오도록 해야 겠군!"); //큘
        sentences2.Add("잠깐 큘, 우리 내기 하나 하는 거 어때?"); //칼
        sentences2.Add("무슨 내기?"); //큘
        sentences2.Add("넌 지금도 네가 이 왕국의 기사단장이었어야 했다고 생각하잖아."); //칼
        sentences2.Add("당연한 거 아닌가? 넌 그냥 어쩌다 내 자리를 갖게 된 것뿐이야!"); //큘
        sentences2.Add("그럼 그때처럼 겨루자. 우리 중 누가 주어진 숫자를 더 빨리 만들어내는지!"); //칼
        sentences2.Add("칼. 넌 내가 아직도 그런 허접한 공격이나 할 줄 아는 거냐?!"); //큘
        sentences2.Add("왜? 자신없어? 네가 나보다 정말 강하다면 네 가장 약한 수로도 날 이겨야지!"); //칼
        sentences2.Add("그래, 너를 내 손으로 죽여주마. 그때와는 차원이 다른 내 진짜 실력을 보여주지!"); //큘
        sentences2.Add("공중에 떠있는 숫자를 더 빠르게 맞히는 사람이 이기는 거야."); //칼
        sentences2.Add("내가 바본 줄 알아?! 꾸물대지 말고 시작해!"); //큘
        size = sentences2.Count;

        s = 0;
        SpriteChange();
        s = 11;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences2[i];
    }
    public void Story2_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 2.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences2_2 = new List<string>();
        //0, 1, 3
        sentences2_2.Add("큭..."); //큘
        sentences2_2.Add("그때나 지금이나... 너만 없었으면..."); //큘
        sentences2_2.Add("아니! 넌 그때도 지금도 내가 없어도! 네 그 악한 마음이 남아있는 한, 네가 원하는 대로 할 수 없을 거야!!!"); //칼
        sentences2_2.Add("헛소리 하지 마!"); //큘
        size = sentences2_2.Count;

        s = 0;
        SpriteChange();
        s = 9;
        SpriteChange();
        Storycul();
        i = 0;
        storytext.text = sentences2_2[i];
    }

    public void Story3On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 3;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences3 = new List<string>();
        //1, 2
        sentences3.Add("그건...!"); //칼
        sentences3.Add("넌 이 케르원기가 가진 힘을 몰라!"); //큘
        sentences3.Add("이걸로 내가 어떤 일을 할 수 있는지 제대로 알게 해 줘야겠군!"); //큘
        size = sentences3.Count;

        s = 12;
        SpriteChange();
        s = 11;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences3[i];
    }
    public void Story3_1On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 3.1f;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences3_1 = new List<string>();
        sentences3_1.Add("(케르원기에서 이상한 빛이...?)"); //칼
        size = sentences3_1.Count;

        s = 0;
        SpriteChange();
        s = 11;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences3_1[i];
    }
    public void Story3_15On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 3.15f;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences3_15 = new List<string>();
        sentences3_15.Add("가라!"); //큘
        size = sentences3_15.Count;

        s = 0;
        SpriteChange();
        s = 6;
        SpriteChange();
        Storycul();
        i = 0;
        storytext.text = sentences3_15[i];
    }
    public void Story3_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 3.5f;

        playerimage1.SetActive(true);
        bossimage1.SetActive(true);
        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        s = 12;
        SpriteChange();
        s = 6;
        SpriteChange();
        sentences3_2 = new List<string>();
        sentences3_2.Add("!!!"); //칼, 큘 동시에
        size = sentences3_2.Count;

        i = 0;
        storytext.text = sentences3_2[i];
    }

    public void Story4On()
    {
        Debug.Log("thth");
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 4;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences4 = new List<string>();
        sentences4.Add("콜록콜록!"); //칼
        sentences4.Add("(몸에 힘이 들어가지 않는다.)"); //칼
        sentences4.Add("큘, 그건 네가 통제하기엔 버거운 물건이야..."); //칼
        size = sentences4.Count;

        s = 7;
        SpriteChange();
        s = 11;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences4[i];
    }
    public void Story4_2On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 4.5f;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences4_2 = new List<string>();
        //1, 2, 3
        sentences4_2.Add("!!! 어디 가는 거야! 당장 케르원기를 내놔!"); //칼
        sentences4_2.Add("이번엔 물러나지만, 그때처럼 좌절하지 않고 언젠간 널 밟아버릴 거야."); //큘
        sentences4_2.Add("내가 지나가는 자리마다 무너져가는 세상을 보며 너도 내가 느꼈던 기분을 느끼게 될 거야."); //큘
        sentences4_2.Add("또 보자, 칼."); //큘
        sentences4_2.Add("안돼! 당장 멈춰!!!"); //칼
        size = sentences4_2.Count;

        s = 7;
        SpriteChange();
        s = 8;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences4_2[i];
    }

    public void Story5On()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().PauseMode();
        GameObject.Find("Stage").GetComponent<Stage3>().story = 5;

        canvas.SetActive(true);
        background1.SetActive(true);
        textbox1.SetActive(true);
        nextbutton1.SetActive(true);

        sentences5 = new List<string>();
        sentences5.Add("...큘."); //칼
        size = sentences5.Count;

        s = 7;
        SpriteChange();
        s = 8;
        SpriteChange();
        Storykal();
        i = 0;
        storytext.text = sentences5[i];
    }

    void Storykal()
    {
        playerimage1.SetActive(true);
        bossimage1.SetActive(false);
    }
    void Storycul()
    {
        playerimage1.SetActive(false);
        bossimage1.SetActive(true);
    }

    public void SpriteChange()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("story");
        SpriteRenderer spriteA = playerimage1.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteB = bossimage1.GetComponent<SpriteRenderer>();
        if (s == 0)
        {
            spriteA.sprite = sprites[s];
        }
        else if (s == 1)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 2)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 3)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 4)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 5)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 6)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 7)
        {
            spriteA.sprite = sprites[s];
        }
        else if (s == 8)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 9)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 10)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 11)
        {
            spriteB.sprite = sprites[s];
        }
        else if (s == 12)
        {
            spriteA.sprite = sprites[s];
        }
        else if (s == 13)
        {
            spriteA.sprite = sprites[s];
        }
    }

    public void StoryOff()
    {
        GameObject.Find("Stage").GetComponent<Stage3>().ResumeMode();

        canvas.SetActive(false);
        background1.SetActive(false);
        playerimage1.SetActive(false);
        bossimage1.SetActive(false);
        textbox1.SetActive(false);
        nextbutton1.SetActive(false);

        clickNextButton = false;
        if (GameObject.Find("Stage").GetComponent<Stage3>().story == 2)
        {
            GameObject.Find("Stage").GetComponent<Stage3>().CulSkill2();
        }if (GameObject.Find("Stage").GetComponent<Stage3>().story == 1.5f)
        {
            GameObject.Find("Stage").GetComponent<Stage3>().CulSkill1();
        }
        if(GameObject.Find("Stage").GetComponent<Stage3>().story == 3)
        {
            GameObject.Find("KerWongi").GetComponent<KerWongiScript>().twingklesound();
        }
        if(GameObject.Find("Stage").GetComponent<Stage3>().story == 3.5)
        {
            GameObject.Find("KerWongi").GetComponent<KerWongiScript>().BoomSound();
        }
        GameObject.Find("Stage").GetComponent<Stage3>().story = 0;
    }
}