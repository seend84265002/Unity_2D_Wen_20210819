using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [Header("X邊界最小值")]
    public float Xmin;
    [Header("X邊界最大值")]
    public float Xmax;
    [Header("Y邊界最小值")]
    public float Ymin;
    [Header("Y邊界最大值")]
    public float Ymax;
    [Header("多少時間產生一個敵機")]
    public float Timer;
    [Header("敵機")]
    public GameObject[] Enemys;
    //public GameObject Enemys;
    [Header("敵機產生的位置")]
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
    {   //一台敵機    
        // Instantiate(Enemys, new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        //兩個參數範圍隨機Random.Range(最小值，最大值)
        //動態生成Instantiate(產生物件，產生的位置，產生以後的角度)
        //Enemys[Random.Range(0, Enemys.Length)] 隨機產生敵機陣列中其中一台敵機出來
        //new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation)敵機產生的位置的X值須作隨機，其餘參數位置預設為不變
        Instantiate(Enemys[0], new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        Instantiate(Enemys[1], new Vector3(EnemyPos.position.x,Random.Range(Ymin, Ymax), EnemyPos.position.z), EnemyPos.rotation);
    }

}
