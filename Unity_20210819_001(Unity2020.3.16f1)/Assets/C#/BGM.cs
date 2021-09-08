using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    //[Header("�I������")]
    //public AudioSource BGM_Audio;
    [Header("����qSlider")]
    public Slider AudioSlider;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;
        
        if (staticvar.isFirst)
        {
            staticvar.SaveAudiovolume = 1f;   //�]�w���֦۰ʼ���
            staticvar.isFirst = false;
        }
       
        //���X�ڭ��x�s���ƭȨ�AudioSlider
        //����� AudioSlider = �����ܼưѼ�
        AudioSlider.value=staticvar.SaveAudiovolume;

    }

    // Update is called once per frame
    void Update()
    {
        //  AudioSlider.value 
        // Slider���ƭ� = 0f-1f
        //�����n���վ� = Slider �վ㪺�ƭ�
        AudioListener.volume = AudioSlider.value;
        //
        //�x�s���  �����ܼưѼ� = AudioSlider
        staticvar.SaveAudiovolume = AudioSlider.value;

    }
    //�����n���}��
    public void ControlBGM(bool Control)
    {
        if (Control)        
        {
            //�p�G�OTrue �n������
            //BGM_Audio.Play();
            AudioListener.pause = false;
            // �����n���}�_

        }
        else       
        {
            //�p�G�OFalse �n���Ȱ�
            //BGM_Audio.Stop();
            AudioListener.pause = true;
            // �����n���}�_
        }


    }




}
