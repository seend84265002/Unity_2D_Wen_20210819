using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("玩家移動速度")]
    public float Speed;
    [Header("玩家飛機X最大值")]
    public float XMax;
    [Header("玩家飛機X最小值")]
    public float XMin;
    [Header("玩家飛機Y最大值")]
    public float YMax;
    [Header("玩家飛機Y最小值")]
    public float YMin;
    [Header("偵測滑鼠/手指是否有點擊飛機")]
    public bool FingerStata;

    [Header("判斷是否已經開始控制搖桿")]
    public bool JoystickState;
    [Header("判斷操控方式是否為搖桿")]
    public bool IsJoystick;
    public enum PlayerStatus
    {
        Acceleration,
        Finger,
        Joystick,
    }
    [Header("選擇玩家在Andriod模式下要用甚麼方式進行遊戲")]
    public PlayerStatus playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //PC
        #if UNITY_STANDALONE_WIN   
        transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);
        #endif

        //Mobile        
        #if UNITY_ANDROID   
        switch (playerStatus)
        {
            case PlayerStatus.Acceleration:
                transform.Translate(Input.acceleration.x * Speed, Input.acceleration.y * Speed, 0);
                //不是使用搖桿
                IsJoystick = false;
                break;
            case PlayerStatus.Finger:
                #region 3D Raycast射線寫法
                /*
                //3D Raycast射線寫法，只能用在3D的collider上
                //從滑鼠點擊的地方，轉換成Unity 3維 中的位置，主攝影機朝此座標位置方向發出一條射線
                Ray ray = Camera.main.ScreenPointToRay(Input.mouseScrollDelta);
                //判斷射線是否有打到物體
                RaycastHit hit;
                //發射射線
                if (Physics.Raycast(ray,out hit,10000f))
                {
                    //從主攝影機的位置為起點-射線打到物件的未產生一條線，此線只有在Unity編譯視窗可以看到
                    Debug.DrawLine(ray.origin, hit.point);
                    //如果射線打到的物件名稱為玩家
                    if(hit.collider.name == "Player")
                    {
                        FingerStata = true;
                    }else{
                        FingerStata = false;
                    }
                }
                */
                #endregion
                //2D Raycast 寫法，只能用在2D的collider
                //如果按下滑鼠左鍵
                if (Input.GetMouseButton(0)){

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //朝攝影機發出一條2維射線
                    RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction, 10000f);
                    //判斷射線是否有打到玩家
                    if (hit2D.collider.name == "BG")
                    {
                        FingerStata = true;
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    FingerStata = false;
                }
                //偵測滑鼠位置 Input.mousePostion
                //螢幕的贆位置換成Untiy內3維座標的方式  Camera.main.ScreenToWorldPoint(滑鼠座標)
                // Untiy 內建3維位置轉換座標位置 Camera.main.WorldToScreenPoint (Untiy 內建座標)
                // Debug.Log(Input.mousePosition);   //滑鼠在遊戲畫面的座標
                //如果手指/滑鼠點了飛機
                if (FingerStata)
                {
                    //將滑鼠點擊的地方轉換成Unity內3維座標
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //飛機的座標位置讀取到滑鼠/手指點擊轉換後的座標值
                    transform.position = new Vector3(pos.x, pos.y, 0f);
                }
                //不是使用搖桿
                IsJoystick = false;
                break;
                
                case PlayerStatus.Joystick:
                    //使用搖桿
                    IsJoystick = true;

                break;
        }
 
        #endif
       
        
        //玩家的座標位置=三維;
        //Mathf 數學.Clamp 限制 (要限制的參數,最小值，最大值)，切記最小值不可與最大值顛倒
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, XMin, XMax), 
                                 Mathf.Clamp(transform.position.y, YMin, YMax), transform.position.z); 
        }

    /*
    //當滑鼠/手指點擊飛機(玩家)
    private void OnMouseDown()
    {
        FingerStata = true;
    }
    //當滑鼠/手指離開飛機(玩家)
    public void OnMouseUp()
    {
        FingerStata = false;
    }
    */

    //開始操控搖桿
    public void isUsingJoystick()
    {
        JoystickState = true;
    }
    //結束操控搖桿
    public void IsntUsingJoystick()
    {
        JoystickState = false;
    }
    //正是使用搖桿
    public void isUsingJoystick(Vector3 pos)
    {
        if(JoystickState && IsJoystick)
        {
            transform.Translate(pos.x * Speed * Time.deltaTime, pos.y * Speed* Time.deltaTime,0);
        }
    }


}
