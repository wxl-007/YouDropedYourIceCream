using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region init all
    GameObject buttonsMenu;
    GameObject optionsMenu;
    
    void Start()
    {
        Init();
    }
    void Init() {
        buttonsMenu = transform.Find("Buttons").gameObject;
        optionsMenu = transform.Find("Options").gameObject;
    }
    #endregion

    #region Button events
    public void LoadSingleGame() {
        SceneManager.LoadScene("Scene2");
    }

    public void QuitGame() {
        Application.Quit();
    }
 
    public void LoadOptions(bool isLoad) {
        if (optionsMenu&&buttonsMenu) {
            optionsMenu.SetActive(isLoad);
            buttonsMenu.SetActive(!isLoad);
        }
    }
    #endregion


}
