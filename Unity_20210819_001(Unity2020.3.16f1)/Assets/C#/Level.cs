using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //playerPrefs Uninty 內建儲存資料的方式，可以儲存文字，整數，小數
    //PlayerPrefs.SetInt
    //playerPrefs.SetFloat
    //playerPrefs.SetString
    //playerPrefs.GetInt
    //playerPrefs.GetFloat
    //PlayerPrefs.GetString

    //儲存每一個關卡遊戲目標分數-欄位名稱
    string DataName = "AimScore";
    [Header("每一個關卡的目標分數")]
    public int[] TotalLevelAimScore;
    [Header("所有關卡的按鈕")]
    public Button[] LevelButtons;

    void Start()
    {
        //透過for迴圈偵測那些遊戲關卡可以開啟
        for(int id=0;id <= staticvar.NextLevelID; id++)
        {
            if(id<9)
            {
                LevelButtons[id].interactable = true;
            }
        }        

    }

    
    void Update()
    {
        
    }


    // 當按下按鍵跳到另一個場景
    public void NextSceneToLevel1(int LevelID)
    {
        //Debug.Log(TotalLevelAimScore[0]);
        PlayerPrefs.SetInt(DataName, TotalLevelAimScore[LevelID]);
        if(staticvar.NextLevelID < LevelID) staticvar.NextLevelID=LevelID;

        staticvar.NowLevelID = LevelID;
        Application.LoadLevel("Movie");
    }
    public void NextSceneToOtherLevel1(int LevelID)
    {
        PlayerPrefs.SetInt(DataName, TotalLevelAimScore[LevelID]);
        if (staticvar.NextLevelID < LevelID) staticvar.NextLevelID = LevelID;

        staticvar.NowLevelID = LevelID;
        Application.LoadLevel("Game");
    }
    public void NextSceneToMenu()
    {
        Application.LoadLevel("Menu");
    }



}
