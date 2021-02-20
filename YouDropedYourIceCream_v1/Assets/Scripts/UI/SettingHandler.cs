using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingHandler : MonoBehaviour
{

    public List<Toggle> toggles = new List<Toggle>();
    int curDifficultyLevel=2;
    void Start()
    {
        curDifficultyLevel = 2;
        toggles[curDifficultyLevel].isOn = true;
    }

    void OnEnable()
    {
        toggles[curDifficultyLevel].isOn = true;
    }

    public void CheckDifficulty() {
        for (int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].isOn) {
                curDifficultyLevel = i;
            }
        }
    }
    public int GetDifficulty (){ 
        return curDifficultyLevel;
    }


    public void LoadHomeScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
