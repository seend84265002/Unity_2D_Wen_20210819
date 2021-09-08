using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    //[Header("背景音樂")]
    //public AudioSource BGM_Audio;
    [Header("控制音量Slider")]
    public Slider AudioSlider;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;
        
        if (staticvar.isFirst)
        {
            staticvar.SaveAudiovolume = 1f;   //設定音樂自動撥放
            staticvar.isFirst = false;
        }
       
        //取出我們儲存的數值到AudioSlider
        //取資料 AudioSlider = 全域變數參數
        AudioSlider.value=staticvar.SaveAudiovolume;

    }

    // Update is called once per frame
    void Update()
    {
        //  AudioSlider.value 
        // Slider的數值 = 0f-1f
        //整體聲音調整 = Slider 調整的數值
        AudioListener.volume = AudioSlider.value;
        //
        //儲存資料  全域變數參數 = AudioSlider
        staticvar.SaveAudiovolume = AudioSlider.value;

    }
    //控制聲音開關
    public void ControlBGM(bool Control)
    {
        if (Control)        
        {
            //如果是True 聲音撥放
            //BGM_Audio.Play();
            AudioListener.pause = false;
            // 整體聲音開起

        }
        else       
        {
            //如果是False 聲音暫停
            //BGM_Audio.Stop();
            AudioListener.pause = true;
            // 整體聲音開起
        }


    }




}
