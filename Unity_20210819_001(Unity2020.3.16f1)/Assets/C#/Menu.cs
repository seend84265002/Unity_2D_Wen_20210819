using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("放入專案中的BGM物件")]
    public GameObject BGM;
    void Awake()
    {
        //找尋物件-名字GameObject.Find("物件名稱")
        //找尋物件-標籤
        //單數 GameObject.FindWithTag("標籤名稱")
        //複數 GameObject.FindGameObjectsWithTag("標籤名稱")
        //如果場景上面沒有半個BGM物件
        if (GameObject.FindGameObjectsWithTag("BGM").Length < 1){
            //動態生成Instantiate(要生成的物件，生成的位置，生成的數值)
            //動態生成NGM
            //生成的位置如果要默認，寫法為 transform.position
            //如果位置要設定為某一個位置點，寫法為 new Vector3 (帶入3維位置)
            //生成的角度值如果要默認，寫法為 transform.rotation
            Instantiate(BGM ,new Vector3(0f,0f,0f),transform.rotation);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //public 公開:可以讓其他物件或程式碼讀取呼叫
    //praivate 私有:無法讓其他物件或程式碼讀取呼叫
    public void LoadScence()
    {
        //Appliction.LoadLevel 切換場景 ("場景名稱")
        //Appliction.LoadLevel 切換場景 (0);輸入場景裡面的ID  Application.LoadLevel(1);
        //Appliction.LoadedLevel 讀取剛前場景的名稱(Applicatiom.loadedLevel):重新讀取當前場景
        Application.LoadLevel("Level");
        
    }
    public void QuitGame()
    {   //Application.Quit(); 關閉遊戲執行檔案
        Application.Quit();
    }
}
