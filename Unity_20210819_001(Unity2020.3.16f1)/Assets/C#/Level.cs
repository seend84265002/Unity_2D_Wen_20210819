using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextSceneToLevel1()
    {
        Application.LoadLevel("Movie");
    }
    public void NextSceneToOtherLevel1()
    {
        Application.LoadLevel("Game");
    }
    public void NextSceneToMenu()
    {
        Application.LoadLevel("Menu");
    }



}
