using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    
    public GameObject SettingMenuUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void StartGame ()//現在是直接進關卡內 之後要進章節選單
    {
       SceneManager.LoadScene("TestLevel");
    }
public void LoadGame()//先進存檔選單但沒有讀檔功能
    {

    }
public void OpenSetting ()
    {
        SettingMenuUI.SetActive(true);
    }
public void ExitSetting ()
    {
        SettingMenuUI.SetActive(false);
    }
}
