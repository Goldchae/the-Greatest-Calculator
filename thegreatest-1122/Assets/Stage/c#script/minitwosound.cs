using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minitwosound : MonoBehaviour
{
    bool dedestroy = true;

    private void Awake()
    {
        var obj = FindObjectsOfType<minitwosound>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update(){
        if (dedestroy){
            if (SceneManager.GetActiveScene().name == "Stage 2" || SceneManager.GetActiveScene().name == "Stagehome"){
                Destroy(gameObject);
                dedestroy = false;
            }
        }
    }
}