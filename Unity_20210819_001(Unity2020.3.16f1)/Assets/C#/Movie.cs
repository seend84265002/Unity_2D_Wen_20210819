using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//引用Unity Video程式庫
using UnityEngine.Video;
//新版本跳場景寫法，需先引用SceneManager程式庫
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour
{
    [Header("影片VideoPlayer物件")]
    public VideoPlayer MovieObject;
    //偵測是否可以開始偵測影片撥放完畢
    // bool Run;
    //計時器
    // float Timer;

    // Start is called before the first frame update
    void Start()
    {
        //影片的音量=Slider暫存的音量
        MovieObject.SetDirectAudioVolume(0, staticvar.SaveAudiovolume);
        //找尋場景中的BGM物件 讓AudioSource元件先進行關閉
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("MovieObject.frame:"+MovieObject.frame);
        // Debug.Log("MovieObject.frameCount:"+Convert.ToInt64(MovieObject.frameCount));
        //如果影片目前撥放進度=影片frame總長度 代表影片撥放完畢
        if (MovieObject.frame >= Convert.ToInt64(MovieObject.frameCount) - 2)
        {
            //將BGM的AudioSource元件開啟
            GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = true;
            //跳到下一個場景
            SceneManager.LoadScene("Game");
        }
        /*
        //遊戲開始後，開始計時
        Timer+=Time.deltaTime;
        //如果計時器超過3秒
        if(Timer>3f){
            //Run為true開始偵測影片是否撥放完畢
          Run=true;  
        }
        //如果兩個條件成立，影片撥放完畢或Run=true
        if(!MovieObject.isPlaying&&Run){
            //將BGM的AudioSource元件開啟
             GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled=true;
            //跳到下一個場景
              SceneManager.LoadScene("Game");
        }
        */
    }
    public void SkipButton()
    {
        //將BGM的AudioSource元件開啟
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = true;
        //跳到下一個場景
        SceneManager.LoadScene("Game");
    }



}
