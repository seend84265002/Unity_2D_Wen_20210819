using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region 動態生成敵機
    [Header("X邊界最小值")]
    public float Xmin;
    [Header("X邊界最大值")]
    public float Xmax;
    [Header("Y邊界最小值")]
    public float Ymin;
    [Header("Y邊界最大值")]
    public float Ymax;
    [Header("多少時間產生一個敵機")]
    public float Timer;
    [Header("敵機")]
    public GameObject[] Enemys;
    //public GameObject Enemys;
    [Header("敵機產生的位置")]
    public Transform EnemyPos;
    #endregion
    #region 玩家血條/血量
    [Header("設定玩家初始血量")]
    public float TotalPlayerHP;
    //程式中計算玩家的血量
    float PlayerScriptHP;
    [Header("傷害的血量")]
    public float HurtPlayerHP;
    [Header("玩家的血條")]
    public Image PlayerHPBar;
    #endregion

    #region 得分數
    [Header("總分數")]
    public int TotalScore;
    [Header("打死一隻敵機得分數")]
    public int AddScore;
    [Header("玩家總分數")]
    public Text ScoreText;
    #endregion
    [Header("遊戲暫停畫面")]
    public GameObject GamePauseUI;

    string ScoreDataName ="Score";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ProduceEnemy", Timer, Timer);
        //程式中玩家得血量= 屬性面板玩家的血量
        PlayerScriptHP = TotalPlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ProduceEnemy()
    {   //一台敵機    
        // Instantiate(Enemys, new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        //兩個參數範圍隨機Random.Range(最小值，最大值)
        //動態生成Instantiate(產生物件，產生的位置，產生以後的角度)
        //Enemys[Random.Range(0, Enemys.Length)] 隨機產生敵機陣列中其中一台敵機出來
        //new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation)敵機產生的位置的X值須作隨機，其餘參數位置預設為不變
        Instantiate(Enemys[Random.Range(0,Enemys.Length)], new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        //Instantiate(Enemys[1], new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z), EnemyPos.rotation);
        
    
    }
    //當敵機子彈打到玩家
    public void HurtPlayer()
    {
        //目前玩家程式中的血量 = 玩家程式中的血量-傷害量;
        
        PlayerScriptHP -= HurtPlayerHP;
        //UI Image fillAmount回傳值為小數 ，所以必須將玩家血量做換算 -> 玩家程式中的血量/屬性面板中的血量
        PlayerHPBar.fillAmount = PlayerScriptHP / TotalPlayerHP;
        if (PlayerScriptHP <= 0)
        {
            PlayerPrefs.SetInt(ScoreDataName, TotalScore);
            //跳換至GameOver場景
            Application.LoadLevel("GameOver");
            
        }
    }

    public void Total_Score()
    {
        TotalScore += AddScore;
        ScoreText.text = "分數 : " + TotalScore;
    }
    //整體遊戲時間暫停，但Updata Function 其實還是有一直在執行
    public void Stop()
    {
        GamePauseUI.SetActive(true);
        //Time.timeScale = 0;整體遊戲時間暫停，如果沒有在遊戲一開始復原，關掉遊戲在重開啟也還是呈現暫停的狀態
        Time.timeScale = 0;
    }

    public void Countinue()
    {
        GamePauseUI.SetActive(false);
        //Time.timeScale=1,恢復整體運行;
        Time.timeScale = 1;
    }

    public void ToMenu()
    {
        //Time.timeScale = 1 ,恢復整體運行;
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }


}
