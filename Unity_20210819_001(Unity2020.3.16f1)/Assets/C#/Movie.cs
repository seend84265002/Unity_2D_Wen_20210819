using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//�ޥ�Unity Video�{���w
using UnityEngine.Video;
//�s�����������g�k�A�ݥ��ޥ�SceneManager�{���w
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour
{
    [Header("�v��VideoPlayer����")]
    public VideoPlayer MovieObject;
    //�����O�_�i�H�}�l�����v�����񧹲�
    // bool Run;
    //�p�ɾ�
    // float Timer;

    // Start is called before the first frame update
    void Start()
    {
        //�v�������q=Slider�Ȧs�����q
        MovieObject.SetDirectAudioVolume(0, staticvar.SaveAudiovolume);
        //��M��������BGM���� ��AudioSource������i������
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("MovieObject.frame:"+MovieObject.frame);
        // Debug.Log("MovieObject.frameCount:"+Convert.ToInt64(MovieObject.frameCount));
        //�p�G�v���ثe����i��=�v��frame�`���� �N��v�����񧹲�
        if (MovieObject.frame >= Convert.ToInt64(MovieObject.frameCount) - 2)
        {
            //�NBGM��AudioSource����}��
            GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = true;
            //����U�@�ӳ���
            SceneManager.LoadScene("Game");
        }
        /*
        //�C���}�l��A�}�l�p��
        Timer+=Time.deltaTime;
        //�p�G�p�ɾ��W�L3��
        if(Timer>3f){
            //Run��true�}�l�����v���O�_���񧹲�
          Run=true;  
        }
        //�p�G��ӱ��󦨥ߡA�v�����񧹲���Run=true
        if(!MovieObject.isPlaying&&Run){
            //�NBGM��AudioSource����}��
             GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled=true;
            //����U�@�ӳ���
              SceneManager.LoadScene("Game");
        }
        */
    }
    public void SkipButton()
    {
        //�NBGM��AudioSource����}��
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = true;
        //����U�@�ӳ���
        SceneManager.LoadScene("Game");
    }



}
