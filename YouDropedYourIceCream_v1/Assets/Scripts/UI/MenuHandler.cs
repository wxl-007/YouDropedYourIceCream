using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    //Singleton pattern
    public static MenuHandler S;
    void Start()
    {
        S = this;
    }
    // Update is called once per frame
    void Update()
    {




    }

    public void ButtonClicked()
    {
        Debug.Log("The button was clicked!");
    }


    public void ButtonClickedWithStringParameter(string parameter)
    {
        Debug.Log("The button was clicked! parameter=" + parameter);
    }
    public void GoToScene(string sceneName)
    {
        string num =  sceneName.Substring(sceneName.Length-1);
        PlayerPrefs.SetInt("curScene", int.Parse(num));
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonClickedWithIntParameter(int parameter)
    {
        Debug.Log("The button was clicked! parameter=" + parameter);
    }

}
