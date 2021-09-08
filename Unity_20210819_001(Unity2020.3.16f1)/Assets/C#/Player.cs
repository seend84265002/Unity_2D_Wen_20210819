using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("���a���ʳt��")]
    public float Speed;
    [Header("���a����X�̤j��")]
    public float XMax;
    [Header("���a����X�̤p��")]
    public float XMin;
    [Header("���a����Y�̤j��")]
    public float YMax;
    [Header("���a����Y�̤p��")]
    public float YMin;

    public enum PlayerStatus
    {
        Acceleration,
        Finger,
        Joystick,
    }
    [Header("��ܪ��a�bAndriod�Ҧ��U�n�άƻ�覡�i��C��")]
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
       
        
        //���a���y�Ц�m=�T��;
        //Mathf �ƾ�.Clamp ���� (�n����Ѽ�,�̤p�ȡA�̤j��)�A���O�̤p�Ȥ��i�P�̤j���A��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, XMin, XMax), 
                                 Mathf.Clamp(transform.position.y, YMin, YMax), transform.position.z); 
        
    }
}
