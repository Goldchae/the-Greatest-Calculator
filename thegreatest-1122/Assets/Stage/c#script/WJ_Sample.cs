using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WJ_Sample : MonoBehaviour
{
    public GameObject BackgroundMusic;
    AudioSource backmusic;

    AudioSource audioSource;
    public AudioClip Ranksword;
    public AudioClip RankswordP;

    void PlaySound(string action){
        switch (action){
            case "Ranksword":
                audioSource.clip = Ranksword;
                break;
            case "RankswordP":
                audioSource.clip = RankswordP;
                break;
        }
        audioSource.Play();
    }

    public  GameObject swordeffect;
    public Animator swordanimator; 

    public WJ_Conn scWJ_Conn;
    public GameObject goPopup_Level_Choice;
    public TEXDraw txQuestion;
    public Button []btAnsr = new Button[4];
    public Text txState;

    public Button btStart;

    protected TEXDraw[] txAnsr;

    public GameObject player;//애니매이션
    public Animator animator; 
    public GameObject rankingplayer;
    public Animator Ranimator; 
    public GameObject versus;

    private GameObject timebox; //엔딩
    private GameObject endingback;
    private GameObject endingPlayer;
    private GameObject winwin;
    private GameObject endingcanvas;
    private bool endingbool = true;
    public GameObject scorecanvas;
    public TextMeshProUGUI sscore;
    

    public TextMeshProUGUI TextTMP;// 검술 숙련도- 점수
    int swordscore = 0;
    int testscore = 0;
    bool swordtrue = true;

    public int healthbar = 100;  // 체력바
    public GameObject healthbarObject;
    public int healthbarP = 100; 
    public GameObject healthbarObjectP;

    public Rankingapi scRankingapi; // api
    public InputField InputField;
    string Username = InputField.Username; 

    protected enum STATE
    {
        DN_SET,         // 진단평가 진행해야 하는 단계
        DN_PROG,        // 진단평가 진행중
        LEARNING,       // 학습 진행중
    }

    protected STATE eState;
    protected bool bRequest;

    protected int nDigonstic_Idx;   // 진단평가 인덱스

    protected WJ_Conn.Learning_Data cLearning;
    protected int nLearning_Idx;     // Learning 문제 인덱스
    protected string[] strQstCransr = new string[8];        // 사용자가 보기에서 선택한 답 내용
    protected long[] nQstDelayTime = new long[8];           // 풀이에 소요된 시간




    // Start is called before the first frame update
    void Awake()
    {
        swordeffect.SetActive(false);
        swordanimator = swordeffect.GetComponent<Animator>(); 

        backmusic = BackgroundMusic.GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        animator = player.GetComponent<Animator>(); //애니매이션
        Ranimator = rankingplayer.GetComponent<Animator>(); //애니매이션
        scorecanvas.SetActive(false); //엔딩스코어
        Invoke("Versus",1.3f);

        NativeLeakDetection.Mode = NativeLeakDetectionMode.EnabledWithStackTrace;

        eState = STATE.DN_SET;
        goPopup_Level_Choice.active = false;

        cLearning = null;
        nLearning_Idx = 0;

        txState.text = "상태 : 진단 평가 미수행";

        txAnsr = new TEXDraw[btAnsr.Length];
        for (int i = 0; i < btAnsr.Length; ++i)
            txAnsr[i] = btAnsr[i].GetComponentInChildren<TEXDraw>();

        SetActive_Question(false);
        btStart.gameObject.active = true;

        bRequest = false;
    }

    void Versus(){
        versus.SetActive(false);
    }

    // 문제 출제 버튼 클릭시 호출
    public void OnClick_MakeQuestion()
    { 
        switch (eState)
        {
            case STATE.DN_SET: DoDN_Start(); break;
            //호출 안됨. case STATE.DN_PROG: DoDN_Prog(); break;
            case STATE.LEARNING: DoLearning(); break;
        }        
    }




    // 학습 수준 선택 팝업에서 사용자가 수준에 맞는 학습을 선택시 호출
    public void OnClick_Level(int _nLevel)
    {

        nDigonstic_Idx = 0;
        SetActive_Question(true);
        btStart.gameObject.active = false;

        // 문제 요청
        scWJ_Conn.OnRequest_DN_Setting(_nLevel);

        // 수준 선택 팝업 닫기
        goPopup_Level_Choice.active = false;

        bRequest = true;
    }


    // 보기 선택
    public void OnClick_Ansr(int _nIndex)
    {
        switch (eState)
        {
            case STATE.DN_SET:
            case STATE.DN_PROG:
                {
                    // 다음문제 출제
                    DoDN_Prog(txAnsr[_nIndex].text);
                }
                break;
            case STATE.LEARNING:
                {
                    // 선택한 정답을 저장함
                    strQstCransr[nLearning_Idx - 1] = txAnsr[_nIndex].text;
                    nQstDelayTime[nLearning_Idx - 1] = 5000;        // 임시값
                    // 다음문제 출제
                    DoLearning();
                }
                break;
        }
    }





    protected void DoDN_Start()
    {
        goPopup_Level_Choice.active = true;
    }


    protected void DoDN_Prog(string _qstCransr)
    {
        string strYN = "N";
        if (scWJ_Conn.cDiagnotics.data.qstCransr.CompareTo(_qstCransr) == 0){
            strYN = "Y";

            animator.SetTrigger("fight"); //애니
            Ranimator.SetTrigger("R_attacked");
            
            testscore = swordscore; //점수
            swordtrue = true;
            StartCoroutine("scoreanimation"); 
            Invoke("realswordscore", 1f);

            healthbarP -= 13; //상대체력바
            healthbarObjectP.GetComponent<Slider>().value = healthbarP;
            PlaySound("Ranksword");

            swordeffect.SetActive(true);
            swordanimator.SetTrigger("sword");
        }
        else{
            animator.SetTrigger("hurt2");
            Ranimator.SetTrigger("R_attack");

            healthbar -= 20; //체력바
            healthbarObject.GetComponent<Slider>().value = healthbar;
            PlaySound("RankswordP");
        }
        

        scWJ_Conn.OnRequest_DN_Progress("W",
                                         scWJ_Conn.cDiagnotics.data.qstCd,          // 문제 코드
                                         _qstCransr,                                // 선택한 답내용 -> 사용자가 선택한 문항 데이터 입력
                                         strYN,                                     // 정답여부("Y"/"N")
                                         scWJ_Conn.cDiagnotics.data.sid,            // 문제 SID
                                         5000);                                     // 임시값 - 문제 풀이에 소요된 시간

        bRequest = true;
    }


    protected void DoLearning()
    {
        if (cLearning == null)
        {
            nLearning_Idx = 0;
            SetActive_Question(true);
            btStart.gameObject.active = false;

            scWJ_Conn.OnRequest_Learning();            

            bRequest = true;
        }
        else
        {            
            if (nLearning_Idx >= scWJ_Conn.cLearning_Info.data.qsts.Count)
            {
                txState.text = "상태 : 학습 완료";
                scWJ_Conn.OnLearningResult(cLearning, strQstCransr, nQstDelayTime);      // 학습 결과 처리
                cLearning = null;

                SetActive_Question(false);
                btStart.gameObject.active = true;
                return;
            }

            MakeQuestion(cLearning.qsts[nLearning_Idx].qstCn, cLearning.qsts[nLearning_Idx].qstCransr, cLearning.qsts[nLearning_Idx].qstWransr);

            txState.text = "상태 : 문제 학습 " + (nLearning_Idx + 1).ToString();


            ++nLearning_Idx;

            bRequest = false;
        }
    }





    protected void MakeQuestion(string _qstCn, string _qstCransr, string _qstWransr)
    {
        char[] SEP = { ',' };
        string[] tmWrAnswer;
        
        txQuestion.text = scWJ_Conn.GetLatexCode(_qstCn);// 문제 출력
       
        string strAnswer = _qstCransr;  // 문제 정답을 메모리에 넣어둠                
        tmWrAnswer = _qstWransr.Split(SEP, System.StringSplitOptions.None);   // 오답 리스트
        for(int i = 0; i < tmWrAnswer.Length; ++i)
            tmWrAnswer[i] = scWJ_Conn.GetLatexCode(tmWrAnswer[i]);



        int nWrCount = tmWrAnswer.Length;
        if (nWrCount >= 4)       // 5지선다형 이상은 강제로 4지선다로 변경함
            nWrCount = 3;


        int nAnsrCount = nWrCount + 1;       // 보기 갯수
        for (int i = 0; i < btAnsr.Length; ++i)
        {
            if (i < nAnsrCount)
                btAnsr[i].gameObject.active = true;
            else
                btAnsr[i].gameObject.active = false;
        }


        // 보기 리스트에 정답을 넣음.
        int nAnsridx = UnityEngine.Random.Range(0, nAnsrCount);        // 정답 인덱스! 랜덤으로 배치
        for (int i = 0, q = 0; i < nAnsrCount; ++i, ++q)
        {
            if (i == nAnsridx)
            {
                txAnsr[i].text = strAnswer;
                --q;
            }
            else
                txAnsr[i].text = tmWrAnswer[q];
        }


    }




    protected void SetActive_Question(bool _bActive)
    {
        txQuestion.text = "";
        for (int i = 0; i < btAnsr.Length; ++i)
            btAnsr[i].gameObject.active = _bActive;
    }


    // Update is called once per frame
    void Update()
    {
        if (endingbool){
            if (healthbar <= 3){            // 실패엔딩
                Ending1(); 
                Invoke("SceneChange3",2.5f);
                endingbool = false;
            }
        }

        if(bRequest == true && 
           scWJ_Conn.CheckState_Request() == 1)
        {
            switch(eState)
            {
                case STATE.DN_SET:
                    {                        
                        Debug.Log(scWJ_Conn.cDiagnotics.data.qstCransr);
                        MakeQuestion(scWJ_Conn.cDiagnotics.data.qstCn, scWJ_Conn.cDiagnotics.data.qstCransr, scWJ_Conn.cDiagnotics.data.qstWransr);

                        txState.text = "상태 : 진단평가 " + (nDigonstic_Idx + 1).ToString();
                        ++nDigonstic_Idx;

                        eState = STATE.DN_PROG;
                    }
                    break;
                case STATE.DN_PROG:
                    {
                        if (scWJ_Conn.cDiagnotics.data.prgsCd == "E")
                        {
                            SetActive_Question(false);

                            nDigonstic_Idx = 0;
                            txState.text = "상태 : 진단평가 완료";
                            btStart.gameObject.active = true;
                            
                            eState = STATE.LEARNING;            // 진단 학습 완료
                            
                            if (healthbarP <= 3 && healthbar > 3){            // 엔딩
                                Ending2(); 
                            }else if ( healthbar > 3 ){
                                Ending3();
                            } 
                            Invoke("SceneChange3",2.5f);      //홈
                        }
                        else
                        {
                            MakeQuestion(scWJ_Conn.cDiagnotics.data.qstCn, scWJ_Conn.cDiagnotics.data.qstCransr, scWJ_Conn.cDiagnotics.data.qstWransr);

                            txState.text = "상태 : 진단평가 " + (nDigonstic_Idx + 1).ToString();
                            ++nDigonstic_Idx;
                        }
                    }
                    break;
                case STATE.LEARNING:
                    {
                        cLearning = scWJ_Conn.cLearning_Info.data;
                        MakeQuestion(cLearning.qsts[nLearning_Idx].qstCn, cLearning.qsts[nLearning_Idx].qstCransr, cLearning.qsts[nLearning_Idx].qstWransr);
                        txState.text = "상태 : 문제 학습 " + (nLearning_Idx + 1).ToString();

                        ++nLearning_Idx;                        
                    }
                    break;
            }
            bRequest = false;
        }
        
    }
    public void Ending1()//엔딩1- 실패
    {
        backmusic.Pause();
        endingback = Resources.Load<GameObject>("Rending/endingBackground");
        Instantiate(endingback, new Vector3(-0.08f,-0.02f,1f), Quaternion.identity); // 배경이미지 생성
        endingPlayer = Resources.Load<GameObject>("Rending/timeendingplayer1");
        Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-7.17f), Quaternion.identity); //주인공이미지생성
        timebox = Resources.Load<GameObject>("Rending/ending box 2(small)");//박스
        Instantiate(timebox, new Vector3(510f,-208f, 0f), Quaternion.identity);
        endingcanvas = Resources.Load<GameObject>("Rending/EndingCanvas");//캔버스
        Instantiate(endingcanvas, new Vector3(10f,-46.9927f, 0f), Quaternion.identity);
        winwin = Resources.Load<GameObject>("Rending/lose");//lose
        Instantiate(winwin, new Vector3(143f, 300f, -1f), Quaternion.identity);
        string textsscore = swordscore.ToString();
        sscore.text = textsscore;
        scorecanvas.SetActive(true);    //점수 텍스트 
    }
    
    public void Ending2()//엔딩2 - perfect성공
    {
        backmusic.Pause();
        endingback = Resources.Load<GameObject>("Rending/endingBackground");
        Instantiate(endingback, new Vector3(-0.08f,-0.02f,1f), Quaternion.identity); // 배경이미지 생성
        endingPlayer = Resources.Load<GameObject>("Rending/realendingplayer");
        Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-7.17f), Quaternion.identity); //주인공이미지생성
        timebox = Resources.Load<GameObject>("Rending/ending box 2(small)");//박스
        Instantiate(timebox, new Vector3(500f,-225f, 0f), Quaternion.identity);
        endingcanvas = Resources.Load<GameObject>("Rending/EndingCanvas");//캔버스
        Instantiate(endingcanvas, new Vector3(10f,-46.9927f, 0f), Quaternion.identity);
        winwin = Resources.Load<GameObject>("Rending/win"); // Win
        Instantiate(winwin, new Vector3(173f, 274f, -2f), Quaternion.identity);
        string textsscore = swordscore.ToString();
        sscore.text = textsscore;
        scorecanvas.SetActive(true);    //점수 텍스트 
    }
    public void Ending3()//엔딩3 - 성공
    {
        backmusic.Pause();
        endingback = Resources.Load<GameObject>("Rending/endingBackground");
        Instantiate(endingback, new Vector3(-0.08f,-0.02f,1f), Quaternion.identity); // 배경이미지 생성
        endingPlayer = Resources.Load<GameObject>("Rending/realendingplayer");
        Instantiate(endingPlayer, new Vector3(-0.18f,-7.89f,-7.17f), Quaternion.identity); //주인공이미지생성
        timebox = Resources.Load<GameObject>("Rending/ending box 2(small)");
        Instantiate(timebox, new Vector3(500f,-225f, 0f), Quaternion.identity);
        endingcanvas = Resources.Load<GameObject>("Rending/EndingCanvas");//캔버스
        Instantiate(endingcanvas, new Vector3(10f,-46.9927f, 0f), Quaternion.identity);
        winwin = Resources.Load<GameObject>("Rending/win normal");//win normal
        Instantiate(winwin, new Vector3(159f, 290f, -1f), Quaternion.identity);
        string textsscore = swordscore.ToString();
        sscore.text = textsscore;
        scorecanvas.SetActive(true);    //점수 텍스트 
    }

    public void SceneChange3(){//홈이동 / api
        scRankingapi.OnRequest_Api_Ranking_Req(Username, swordscore);  
    }

    IEnumerator scoreanimation(){// 점수애니매이션
        yield return new WaitForSeconds(0.5f);
        while(swordtrue){
            testscore += 10; 
            string swordsString = testscore.ToString();
            TextTMP.text = swordsString; 
            yield return null;
        }
    }
    public void realswordscore(){//찐점수
        swordtrue = false;
        swordscore += 2000; 
        string swordString = swordscore.ToString();
        TextTMP.text = swordString; 
    }
}