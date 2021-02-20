using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleTree : MonoBehaviour
{
    //Public variables
    public GameObject applePrefab;
    public GameObject goldenApplePrefab;
    public GameObject bombPrefab;

    public float speed = 1;
    public float leftAndRightEdge = 10;
    public float chanceToChangeDirection = .1f;
    public float appleDropInterval = 1f; 
    public int direction = 1;

    SettingHandler setting;
  
    void Start()
    {
        if (PlayerPrefs.GetInt("curScene", -1) != 0)
        {
            setting = transform.Find("/Canvas/Setting").GetComponent<SettingHandler>();
            setting.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
        
        InvokeRepeating("DropApple", 2f, appleDropInterval);
    }


    void DropApple()
    {
        GameObject curPrefab = applePrefab;
        if (PlayerPrefs.GetInt("curScene", 0) == 3)
        {
            int dice = (int)Random.Range(0, 5f);
            if (dice == 0) curPrefab = bombPrefab;
            if (dice == 4) curPrefab = goldenApplePrefab;
        }
        GameObject apple = Instantiate(curPrefab) as GameObject;
        apple.transform.position = this.transform.position;
    }
    void Update()
    {
        
        Vector3 pos = this.transform.position;
        float dx = speed * direction * Time.deltaTime;
        pos.x += dx;
        transform.position = pos;
        ChangeDirection(pos.x);
    }

    void ChangeDirection(float px)
    {
        if(px < -leftAndRightEdge)
        {
            direction = 1;
        }else if (px > leftAndRightEdge)
        {
            direction = -1;
        }
    }

    private void FixedUpdate()
    {
        
        if(Random.value < chanceToChangeDirection)
        {
            direction *= -1;
        }
    }

    public void LoadBack()
    {
        setting.CheckDifficulty();
        setting.gameObject.SetActive(false);
        Time.timeScale = 1;
        speed = 40 - setting.GetDifficulty() * 12;
        appleDropInterval = 0.3f + setting.GetDifficulty() * 0.5f;
        CancelInvoke("DropApple");
        InvokeRepeating("DropApple", 1f, appleDropInterval);
    }
    public void LoadSetting()
    {
        Time.timeScale = 0;
        setting.gameObject.SetActive(true);
    }


}
