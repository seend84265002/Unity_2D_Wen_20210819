using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ProduceEnemy", Timer, Timer);
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
        Instantiate(Enemys[0], new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        Instantiate(Enemys[1], new Vector3(EnemyPos.position.x,Random.Range(Ymin, Ymax), EnemyPos.position.z), EnemyPos.rotation);
    }

}
