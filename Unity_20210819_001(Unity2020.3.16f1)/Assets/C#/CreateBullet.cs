using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    [Header("設定固定每多少秒呼叫一次")]
    public float Timer;
    [Header("要生成的子彈物件")]
    public GameObject Bullet;
    [Header("子彈生成的位置")]
    public GameObject BulletPos;

    // Start is called before the first frame update
    void Start()
    {
        //持續呼叫function-InvokeRepeating("function名稱",遊戲開始後要多久進行第一次呼叫function,第二次以後每次Delay多少時間呼叫function)
        //以秒為單位
        InvokeRepeating("ProduceBullet", Timer, Timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ProduceBullet()
    {
        //動態生成物件
        Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
        //Debug.Log("ProduceBullet");
    }
}
