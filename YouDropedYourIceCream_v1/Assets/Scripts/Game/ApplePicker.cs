using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{

    public GameObject basketPrefab;
    int numBaskets=1;
    public float basketMinY = -14f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList;

    int SecondsToWaitBeforeRestart = 0;

    GameObject losePanel;

    void Start()
    {
        if (PlayerPrefs.GetInt("curScene", -1) != 0)
        {
            losePanel = transform.Find("/Canvas/Lose").gameObject;
            losePanel.SetActive(false);
        }
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject basketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketMinY + i * basketSpacingY;
            basketGO.transform.position = pos;
            basketList.Add(basketGO);
        }
        
    }
    public void AppleDestroyed()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject go in apples){
            Destroy(go);
        }

        int basketToGoIndex = basketList.Count - 1;
        GameObject basketToGo = basketList[basketToGoIndex];
        basketList.RemoveAt(basketToGoIndex); 
        Destroy(basketToGo);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    public void TouchBomb() {
        int basketToGoIndex = basketList.Count - 1;
        GameObject basketToGo = basketList[basketToGoIndex];
        basketList.RemoveAt(basketToGoIndex);
        Destroy(basketToGo);

        if (basketList.Count == 0)
        {
            StartCoroutine("Lost");
        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuHandler.S.GoToScene("Main");
        }
    }
}
