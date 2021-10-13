using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string DataName = "AimScore";
    [Header("目標分數文字")]
    public Text AimScoreText;

    string ScoreDataName = "Score";
    [Header("分數文字")]
    public Text ScoreText;

    [Header("Next Game 按鈕")]
    public Button NextGameButton;

    [Header("關卡的文字")]
    public Text LevelText;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(staticvar.NowLevelID);

        LevelText.text = "第"+ (staticvar.NowLevelID+1)+ "關";
        
        AimScoreText.text = "目標分數 : " + PlayerPrefs.GetInt(DataName);

        ScoreText.text = "實際分數 : " + PlayerPrefs.GetInt(ScoreDataName);

        if (PlayerPrefs.GetInt(ScoreDataName) >= PlayerPrefs.GetInt(DataName) || staticvar.NextLevelID != 0)
        {
            NextGameButton.interactable = true;
        }
        else
        {
            NextGameButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //重新遊戲
    public void Regame()
    {
        
        Application.LoadLevel("Game");
    }
    //下一關
    public void NextGame()
    {
        if (staticvar.NextLevelID == Mathf.Clamp(staticvar.NextLevelID, 0, 8) && PlayerPrefs.GetInt(ScoreDataName) >= PlayerPrefs.GetInt(DataName))
        {
            staticvar.NextLevelID++;
        }
        Application.LoadLevel("Level");
    }
    //關閉遊戲
    public void Quit()
    {
        Application.Quit();
    }

}
