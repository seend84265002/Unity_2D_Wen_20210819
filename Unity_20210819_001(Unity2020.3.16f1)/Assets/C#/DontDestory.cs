using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    void Awake()
    {
        // DontDestroyOnLoad ����������ɡA���N�R����������
        // gameObject �N���O���󥻨��ۤv�A�Ҧp���}����BGM�A��gameObject�N���OBGM
        // GameObject �ܼƫ��A

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
