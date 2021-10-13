using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //playerPrefs Uninty �����x�s��ƪ��覡�A�i�H�x�s��r�A��ơA�p��
    //PlayerPrefs.SetInt
    //playerPrefs.SetFloat
    //playerPrefs.SetString
    //playerPrefs.GetInt
    //playerPrefs.GetFloat
    //PlayerPrefs.GetString

    //�x�s�C�@�����d�C���ؼФ���-���W��
    string DataName = "AimScore";
    [Header("�C�@�����d���ؼФ���")]
    public int[] TotalLevelAimScore;
    [Header("�Ҧ����d�����s")]
    public Button[] LevelButtons;

    void Start()
    {
        //�z�Lfor�j�鰻�����ǹC�����d�i�H�}��
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


    // ����U�������t�@�ӳ���
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
