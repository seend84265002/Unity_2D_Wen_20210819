using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("��J�M�פ���BGM����")]
    public GameObject BGM;
    void Awake()
    {
        //��M����-�W�rGameObject.Find("����W��")
        //��M����-����
        //��� GameObject.FindWithTag("���ҦW��")
        //�Ƽ� GameObject.FindGameObjectsWithTag("���ҦW��")
        //�p�G�����W���S���b��BGM����
        if (GameObject.FindGameObjectsWithTag("BGM").Length < 1){
            //�ʺA�ͦ�Instantiate(�n�ͦ�������A�ͦ�����m�A�ͦ����ƭ�)
            //�ʺA�ͦ�NGM
            //�ͦ�����m�p�G�n�q�{�A�g�k�� transform.position
            //�p�G��m�n�]�w���Y�@�Ӧ�m�I�A�g�k�� new Vector3 (�a�J3����m)
            //�ͦ������׭Ȧp�G�n�q�{�A�g�k�� transform.rotation
            Instantiate(BGM ,new Vector3(0f,0f,0f),transform.rotation);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //public ���}:�i�H����L����ε{���XŪ���I�s
    //praivate �p��:�L�k����L����ε{���XŪ���I�s
    public void LoadScence()
    {
        //Appliction.LoadLevel �������� ("�����W��")
        //Appliction.LoadLevel �������� (0);��J�����̭���ID  Application.LoadLevel(1);
        //Appliction.LoadedLevel Ū����e�������W��(Applicatiom.loadedLevel):���sŪ����e����
        Application.LoadLevel("Level");
        
    }
    public void QuitGame()
    {   //Application.Quit(); �����C�������ɮ�
        Application.Quit();
    }
}
