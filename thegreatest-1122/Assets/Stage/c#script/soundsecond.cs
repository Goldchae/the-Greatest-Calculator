using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class soundsecond : MonoBehaviour
{
    bool dedestroy = true;

    private void Awake()
    {
        var obj = FindObjectsOfType<soundsecond>();
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
            if (SceneManager.GetActiveScene().name == "ani" || SceneManager.GetActiveScene().name == "ani1" || SceneManager.GetActiveScene().name == "Minigame2"){
                Destroy(gameObject);
                dedestroy = false;
            }
        }
    }
}