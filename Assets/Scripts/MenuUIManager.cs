using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    public string playerName;

    public void SetLastPlayerData(string name,int score)
    {
        // handle when player data already available
    }
    public bool IsPlayerNameNotEmpty()
    {
        if ((playerNameInput.text!="Type your name" || playerNameInput.text != "Type your name here please!") && playerNameInput.text.Length>0)
        {
            playerName = playerNameInput.text;
            return true;
        }
        else { return false; }
    }
    public void StartNew()
    {
        if (IsPlayerNameNotEmpty())
        {
            MainManager.instance.PlayerName=playerName;
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
        if (IsPlayerNameNotEmpty())
        {
            playerNameInput.text = MainManager.instance.PlayerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
