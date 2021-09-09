using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("多久時間後將子彈刪除")]
    public float DeleteTime;
    [Header("移動速度")]
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        //沒有打到任何敵機的狀態下，過一陣子把自己刪除
        //物件刪除Destroy(要刪除的物件)
        Destroy(gameObject,DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        //子彈移動
        transform.Translate(Vector3.up * Speed);

    }
    /*3D 碰撞偵測-穿透型碰撞，自帶Collider變數
    OnTriggerEnter:當兩的物件一碰撞，如果兩件沒有分離，此function內的程式只會執行一次
    OnTriggerStay:當兩的物件碰撞，如果兩件沒有分離，此function內的程式只會值續執行
    OnTriggerExit:當兩的物件一碰撞，如果兩件分離，此function內的程式只會執行一次
    2D碰撞偵測-穿透型碰撞，自帶Collider2D變數，物件需要加上2D Collider和2D Rigidbody
    OnTriggerEnter2D:當兩的物件一碰撞，如果兩件沒有分離，此function內的程式只會執行一次
    OnTriggerStay2D:當兩的物件碰撞，如果兩件沒有分離，此function內的程式只會值續執行
    OnTriggerExit2D:當兩的物件一碰撞，如果兩件分離，此function內的程式只會執行一次
    */
    void OnTriggerEnter2D(Collider2D hit)
    {
        //如果玩家的子彈，並且碰撞對象為敵機
        if(gameObject.tag == "PlayerBullet" && hit.GetComponent<Collider2D>().tag == "Enemy")
        {
            Debug.Log("攻擊到敵機");
            //玩家的子彈要消失
            Destroy(gameObject);
            //敵機也要消失
            Destroy(hit.gameObject);
        }
        //如果敵機的子彈，並且碰撞對象為玩家
        if (gameObject.tag == "EnemyBullet" && hit.GetComponent<Collider2D>().tag == "Player")
        {
            Debug.Log("攻擊到玩家");
            //敵機的子彈要消失
            Destroy(gameObject);
        }
    }
}
