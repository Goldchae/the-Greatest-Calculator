using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startMusic : MonoBehaviour
{
    public GameObject BackgroundMusic;

    void Awake()
    {
        DontDestroyOnLoad(BackgroundMusic); //배경음악 계속 재생하게(이후 버튼매니저에서 조작)
    }
    void Update(){
        if (SceneManager.GetActiveScene().name == "3 Startani"){
            Destroy(BackgroundMusic);
        }
    }
}
