using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    void Awake()
    {
        // DontDestroyOnLoad 當切換場景時，不意刪除那此物件
        // gameObject 代表的是物件本身自己，例如此腳本給BGM，那gameObject代表的是BGM
        // GameObject 變數型態

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
