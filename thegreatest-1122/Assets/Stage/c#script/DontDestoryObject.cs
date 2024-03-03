using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDestoryObject : MonoBehaviour
{
    bool dedestroy = true;

    private void Awake()
    {
        var obj = FindObjectsOfType<DontDestoryObject>();
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
            if (SceneManager.GetActiveScene().name == "Stagehome" || SceneManager.GetActiveScene().name == "Rankingani" || SceneManager.GetActiveScene().name == "3 Startani"){
                Destroy(gameObject);
                dedestroy = false;
            }
        }
    }
}