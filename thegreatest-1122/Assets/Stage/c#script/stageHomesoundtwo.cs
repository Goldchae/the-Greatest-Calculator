using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stageHomesoundtwo : MonoBehaviour
{
    bool dedestroy = true;

    private void Awake()
    {
        var obj = FindObjectsOfType<stageHomesoundtwo>();
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
            if (SceneManager.GetActiveScene().name == "playerTalk" || SceneManager.GetActiveScene().name == "player2Talk" || SceneManager.GetActiveScene().name == "player3Talk" ||SceneManager.GetActiveScene().name == "4 my_room"){
                Destroy(gameObject);
                dedestroy = false;
            }
        }
    }
}