using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 0;  
    void Awake()
    {
   
        if (PlayerPrefs.HasKey("AppleNumber"))
        {
            score = PlayerPrefs.GetInt("AppleNumber");
        }
        PlayerPrefs.SetInt("AppleNumber", score);

    }
    void Update()
    {
        Text highSpoonTxt = this.GetComponent<Text>();
        highSpoonTxt.text = "High Score: " + score;
        if(score >0){
            PlayerPrefs.SetInt("AppleNumber", score);
        }
    }
}
