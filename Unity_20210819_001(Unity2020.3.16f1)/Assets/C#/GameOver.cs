using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string DataName = "AimScore";
    [Header("�ؼФ��Ƥ�r")]
    public Text AimScoreText;

    string ScoreDataName = "Score";
    [Header("���Ƥ�r")]
    public Text ScoreText;

    [Header("Next Game ���s")]
    public Button NextGameButton;

    [Header("���d����r")]
    public Text LevelText;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(staticvar.NowLevelID);

        LevelText.text = "��"+ (staticvar.NowLevelID+1)+ "��";
        
        AimScoreText.text = "�ؼФ��� : " + PlayerPrefs.GetInt(DataName);

        ScoreText.text = "��ڤ��� : " + PlayerPrefs.GetInt(ScoreDataName);

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
    //���s�C��
    public void Regame()
    {
        
        Application.LoadLevel("Game");
    }
    //�U�@��
    public void NextGame()
    {
        if (staticvar.NextLevelID == Mathf.Clamp(staticvar.NextLevelID, 0, 8) && PlayerPrefs.GetInt(ScoreDataName) >= PlayerPrefs.GetInt(DataName))
        {
            staticvar.NextLevelID++;
        }
        Application.LoadLevel("Level");
    }
    //�����C��
    public void Quit()
    {
        Application.Quit();
    }

}
