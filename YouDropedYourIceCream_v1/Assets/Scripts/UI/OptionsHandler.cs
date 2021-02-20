using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{
    public Toggle toggleMusicBackground;
    public Slider sliderVolume;
    public Text clickCountTextGO;
    int clickCount = 0;

    //Implementing Singleton Pattern
    public static OptionsHandler S;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
        toggleMusicBackground = GameObject.FindGameObjectWithTag("ToggleMusicBackground").GetComponent<Toggle>();
        print("toggleMusicBackground.isOn" + toggleMusicBackground.isOn);

        sliderVolume = GameObject.FindGameObjectWithTag("SliderVolume").GetComponent<Slider>();
        print("sliderVolume.value=" + sliderVolume.value);

        clickCountTextGO.text = "ClickCount:" + clickCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void ButtonClicked()
    {
        Debug.Log("The button was clicked!");
        clickCount += 1;
        clickCountTextGO.text = "ClickCount:" + clickCount.ToString();
    }

}
