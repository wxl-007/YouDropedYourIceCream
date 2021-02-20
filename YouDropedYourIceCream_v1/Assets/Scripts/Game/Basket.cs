using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//New on Oct.06
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreTxt;
    int score = 0;
    ApplePicker applePickerScript = null;
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
    private void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreTxt = scoreGO.GetComponent<Text>();
        scoreTxt.text = "Spoon: "+score;
        applePickerScript = Camera.main.GetComponent<ApplePicker>();

    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag == "Apple")
        {
            Destroy(go);
            score++;
        }
        scoreTxt.text = "Spoon: " + score.ToString();
        PlayerPrefs.SetInt("AppleNumber", score);
        if (score >= 10) {
            SceneManager.LoadScene("GameScene");
        }
        
     
        
    }
}
