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
    [Header("�����ƹ�/����O�_���I������")]
    public bool FingerStata;

    [Header("�P�_�O�_�w�g�}�l����n��")]
    public bool JoystickState;
    [Header("�P�_�ޱ��覡�O�_���n��")]
    public bool IsJoystick;
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
        transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);
        #endif

        //Mobile        
        #if UNITY_ANDROID   
        switch (playerStatus)
        {
            case PlayerStatus.Acceleration:
                transform.Translate(Input.acceleration.x * Speed, Input.acceleration.y * Speed, 0);
                //���O�ϥηn��
                IsJoystick = false;
                break;
            case PlayerStatus.Finger:
                #region 3D Raycast�g�u�g�k
                /*
                //3D Raycast�g�u�g�k�A�u��Φb3D��collider�W
                //�q�ƹ��I�����a��A�ഫ��Unity 3�� ������m�A�D��v���¦��y�Ц�m��V�o�X�@���g�u
                Ray ray = Camera.main.ScreenPointToRay(Input.mouseScrollDelta);
                //�P�_�g�u�O�_�����쪫��
                RaycastHit hit;
                //�o�g�g�u
                if (Physics.Raycast(ray,out hit,10000f))
                {
                    //�q�D��v������m���_�I-�g�u���쪫�󪺥����ͤ@���u�A���u�u���bUnity�sĶ�����i�H�ݨ�
                    Debug.DrawLine(ray.origin, hit.point);
                    //�p�G�g�u���쪺����W�٬����a
                    if(hit.collider.name == "Player")
                    {
                        FingerStata = true;
                    }else{
                        FingerStata = false;
                    }
                }
                */
                #endregion
                //2D Raycast �g�k�A�u��Φb2D��collider
                //�p�G���U�ƹ�����
                if (Input.GetMouseButton(0)){

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //����v���o�X�@��2���g�u
                    RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction, 10000f);
                    //�P�_�g�u�O�_�����쪱�a
                    if (hit2D.collider.name == "BG")
                    {
                        FingerStata = true;
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    FingerStata = false;
                }
                //�����ƹ���m Input.mousePostion
                //�ù����H��m����Untiy��3���y�Ъ��覡  Camera.main.ScreenToWorldPoint(�ƹ��y��)
                // Untiy ����3����m�ഫ�y�Ц�m Camera.main.WorldToScreenPoint (Untiy ���خy��)
                // Debug.Log(Input.mousePosition);   //�ƹ��b�C���e�����y��
                //�p�G���/�ƹ��I�F����
                if (FingerStata)
                {
                    //�N�ƹ��I�����a���ഫ��Unity��3���y��
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //�������y�Ц�mŪ����ƹ�/����I���ഫ�᪺�y�Э�
                    transform.position = new Vector3(pos.x, pos.y, 0f);
                }
                //���O�ϥηn��
                IsJoystick = false;
                break;
                
                case PlayerStatus.Joystick:
                    //�ϥηn��
                    IsJoystick = true;

                break;
        }
 
        #endif
       
        
        //���a���y�Ц�m=�T��;
        //Mathf �ƾ�.Clamp ���� (�n����Ѽ�,�̤p�ȡA�̤j��)�A���O�̤p�Ȥ��i�P�̤j���A��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, XMin, XMax), 
                                 Mathf.Clamp(transform.position.y, YMin, YMax), transform.position.z); 
        }

    /*
    //��ƹ�/����I������(���a)
    private void OnMouseDown()
    {
        FingerStata = true;
    }
    //��ƹ�/������}����(���a)
    public void OnMouseUp()
    {
        FingerStata = false;
    }
    */

    //�}�l�ޱ��n��
    public void isUsingJoystick()
    {
        JoystickState = true;
    }
    //�����ޱ��n��
    public void IsntUsingJoystick()
    {
        JoystickState = false;
    }
    //���O�ϥηn��
    public void isUsingJoystick(Vector3 pos)
    {
        if(JoystickState && IsJoystick)
        {
            transform.Translate(pos.x * Speed * Time.deltaTime, pos.y * Speed* Time.deltaTime,0);
        }
    }


}
