using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minithreesound : MonoBehaviour
{
    bool dedestroy = true;

    private void Awake()
    {
        var obj = FindObjectsOfType<minithreesound>();
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
            if (SceneManager.GetActiveScene().name == "Stage 3" || SceneManager.GetActiveScene().name == "Stagehome"){
                Destroy(gameObject);
                dedestroy = false;
            }
        }
    }
}