using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("產簿笆硉")]
    public float Speed;
    [Header("產诀X程")]
    public float XMax;
    [Header("產诀X程")]
    public float XMin;
    [Header("產诀Y程")]
    public float YMax;
    [Header("產诀Y程")]
    public float YMin;

    public enum PlayerStatus
    {
        Acceleration,
        Finger,
        Joystick,
    }
    [Header("匡拒產Andriod家Α璶ノ或よΑ秈︽笴栏")]
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
        transform.Translate(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed, 0);
        #endif
        //Mobile
        #if UNITY_ANDROID
        switch (playerStatus)
        {
            case PlayerStatus.Acceleration:
                transform.Translate(Input.acceleration.x * Speed, Input.acceleration.y * Speed, 0);
                break;
            case PlayerStatus.Finger:
                break;
            case PlayerStatus.Joystick:
                break;
        }
 
        #endif
       
        
        //產畒夹竚=蝴;
        //Mathf 计厩.Clamp  (璶把计,程程)ち癘程ぃ籔程腁
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, XMin, XMax), 
                                 Mathf.Clamp(transform.position.y, YMin, YMax), transform.position.z); 
        
    }
}
