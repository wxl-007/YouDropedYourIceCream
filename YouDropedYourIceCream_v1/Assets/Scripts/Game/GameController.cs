using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject cone;
    public  GameObject ball;
    readonly int Border = 900;
    public float speed = 1.0f;
    public float v_MoveSpeed = 1.0f;


    void Start()
    {
        cone = GameObject.Find("Cone");
        int spoonNum = 1;
        if (PlayerPrefs.HasKey("AppleNumber"))
        {
            spoonNum = PlayerPrefs.GetInt("AppleNumber");
        }
        for (int i = 0; i < spoonNum; i++)
        {
           
            GameObject tball = Instantiate(ball) as GameObject;
            tball.transform.parent = cone.transform;
            tball.transform.position = cone.transform.position + Vector3.up*60 + Vector3.up * 35*i;
        }
    }

    void Update()
    {
        if (!cone) return;
       

        if (Input.GetKey(KeyCode.D)) {
            cone.GetComponent<Rigidbody2D>().AddForce(Vector2.right*speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            cone.GetComponent<Rigidbody2D>().AddForce(Vector2.left* speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            cone.transform.position +=Vector3.up* v_MoveSpeed*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cone.transform.position += Vector3.down * v_MoveSpeed*Time.deltaTime;
        }
       
        if (cone.GetComponent<RectTransform>().position.x < 0) {
            cone.GetComponent<RectTransform>().position =  Vector3.up * cone.transform.position.y;
        }else if (cone.GetComponent<RectTransform>().position.x > Border)
        {
            cone.GetComponent<RectTransform>().position = Vector3.right* Border + Vector3.up * cone.transform.position.y;
        }


    }
}
