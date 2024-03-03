using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minionesound : MonoBehaviour
{
    bool dedestroy = true;

    private void Awake()
    {
        var obj = FindObjectsOfType<minionesound>();
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
            if (SceneManager.GetActiveScene().name == "Stage 1" || SceneManager.GetActiveScene().name == "Stagehome"){
                Destroy(gameObject);
                dedestroy = false;
            }
        }
    }
}