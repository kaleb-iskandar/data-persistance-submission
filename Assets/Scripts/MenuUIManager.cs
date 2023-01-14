using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SocialPlatforms.Impl;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    

    public bool IsPlayerNameNotEmpty()
    {
        if ((playerNameInput.text!="Type your name" || playerNameInput.text != "Type your name here please!") && playerNameInput.text.Length>0)
        {
            return true;
        }
        else { return false; }
    }
    public void StartNew()
    {
        if (IsPlayerNameNotEmpty())
        {
            MenuManager.instance.playerName = playerNameInput.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            playerNameInput.text = "Type your name here please!";
        }
    }
    public void Exit()
    {
        // save data before exit

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
