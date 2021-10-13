using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region �ʺA�ͦ��ľ�
    [Header("X��ɳ̤p��")]
    public float Xmin;
    [Header("X��ɳ̤j��")]
    public float Xmax;
    [Header("Y��ɳ̤p��")]
    public float Ymin;
    [Header("Y��ɳ̤j��")]
    public float Ymax;
    [Header("�h�֮ɶ����ͤ@�Ӽľ�")]
    public float Timer;
    [Header("�ľ�")]
    public GameObject[] Enemys;
    //public GameObject Enemys;
    [Header("�ľ����ͪ���m")]
    public Transform EnemyPos;
    #endregion
    #region ���a���/��q
    [Header("�]�w���a��l��q")]
    public float TotalPlayerHP;
    //�{�����p�⪱�a����q
    float PlayerScriptHP;
    [Header("�ˮ`����q")]
    public float HurtPlayerHP;
    [Header("���a�����")]
    public Image PlayerHPBar;
    #endregion

    #region �o����
    [Header("�`����")]
    public int TotalScore;
    [Header("�����@���ľ��o����")]
    public int AddScore;
    [Header("���a�`����")]
    public Text ScoreText;
    #endregion
    [Header("�C���Ȱ��e��")]
    public GameObject GamePauseUI;

    string ScoreDataName ="Score";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ProduceEnemy", Timer, Timer);
        //�{�������a�o��q= �ݩʭ��O���a����q
        PlayerScriptHP = TotalPlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ProduceEnemy()
    {   //�@�x�ľ�    
        // Instantiate(Enemys, new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        //��ӰѼƽd���H��Random.Range(�̤p�ȡA�̤j��)
        //�ʺA�ͦ�Instantiate(���ͪ���A���ͪ���m�A���ͥH�᪺����)
        //Enemys[Random.Range(0, Enemys.Length)] �H�����ͼľ��}�C���䤤�@�x�ľ��X��
        //new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation)�ľ����ͪ���m��X�ȶ��@�H���A��l�ѼƦ�m�w�]������
        Instantiate(Enemys[Random.Range(0,Enemys.Length)], new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        //Instantiate(Enemys[1], new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        
    
    }
    //��ľ��l�u���쪱�a
    public void HurtPlayer()
    {
        //�ثe���a�{��������q = ���a�{��������q-�ˮ`�q;
        
        PlayerScriptHP -= HurtPlayerHP;
        //UI Image fillAmount�^�ǭȬ��p�� �A�ҥH�����N���a��q������ -> ���a�{��������q/�ݩʭ��O������q
        PlayerHPBar.fillAmount = PlayerScriptHP / TotalPlayerHP;
        if (PlayerScriptHP <= 0)
        {
            PlayerPrefs.SetInt(ScoreDataName, TotalScore);
            //������GameOver����
            Application.LoadLevel("GameOver");
            
        }
    }

    public void Total_Score()
    {
        TotalScore += AddScore;
        ScoreText.text = "���� : " + TotalScore;
    }
    //����C���ɶ��Ȱ��A��Updata Function ����٬O���@���b����
    public void Stop()
    {
        GamePauseUI.SetActive(true);
        //Time.timeScale = 0;����C���ɶ��Ȱ��A�p�G�S���b�C���@�}�l�_��A�����C���b���}�Ҥ]�٬O�e�{�Ȱ������A
        Time.timeScale = 0;
    }

    public void Countinue()
    {
        GamePauseUI.SetActive(false);
        //Time.timeScale=1,��_����B��;
        Time.timeScale = 1;
    }

    public void ToMenu()
    {
        //Time.timeScale = 1 ,��_����B��;
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }


}
