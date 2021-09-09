using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�h�[�ɶ���N�l�u�R��")]
    public float DeleteTime;
    [Header("���ʳt��")]
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        //�S���������ľ������A�U�A�L�@�}�l��ۤv�R��
        //����R��Destroy(�n�R��������)
        Destroy(gameObject,DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        //�l�u����
        transform.Translate(Vector3.up * Speed);

    }
    /*3D �I������-��z���I���A�۱aCollider�ܼ�
    OnTriggerEnter:���⪺����@�I���A�p�G���S�������A��function�����{���u�|����@��
    OnTriggerStay:���⪺����I���A�p�G���S�������A��function�����{���u�|�������
    OnTriggerExit:���⪺����@�I���A�p�G�������A��function�����{���u�|����@��
    2D�I������-��z���I���A�۱aCollider2D�ܼơA����ݭn�[�W2D Collider�M2D Rigidbody
    OnTriggerEnter2D:���⪺����@�I���A�p�G���S�������A��function�����{���u�|����@��
    OnTriggerStay2D:���⪺����I���A�p�G���S�������A��function�����{���u�|�������
    OnTriggerExit2D:���⪺����@�I���A�p�G�������A��function�����{���u�|����@��
    */
    void OnTriggerEnter2D(Collider2D hit)
    {
        //�p�G���a���l�u�A�åB�I����H���ľ�
        if(gameObject.tag == "PlayerBullet" && hit.GetComponent<Collider2D>().tag == "Enemy")
        {
            Debug.Log("������ľ�");
            //���a���l�u�n����
            Destroy(gameObject);
            //�ľ��]�n����
            Destroy(hit.gameObject);
        }
        //�p�G�ľ����l�u�A�åB�I����H�����a
        if (gameObject.tag == "EnemyBullet" && hit.GetComponent<Collider2D>().tag == "Player")
        {
            Debug.Log("�����쪱�a");
            //�ľ����l�u�n����
            Destroy(gameObject);
        }
    }
}