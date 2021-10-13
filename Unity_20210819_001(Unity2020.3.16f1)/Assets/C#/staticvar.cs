using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticvar : MonoBehaviour
{
    //暫存聲音音量數值
    static public float SaveAudiovolume;
    //判斷是否第一次進入首頁
    static public bool isFirst = true;
    //目前正在確認的遊戲關卡ID
    static public int NowLevelID;
    //可以開啟的遊戲關卡ID
    static public int NextLevelID;
}

