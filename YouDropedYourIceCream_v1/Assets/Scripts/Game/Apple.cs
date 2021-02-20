using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float killY=-20f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < killY)
        {
            Destroy(this.gameObject);
            
            ApplePicker applePickerScript = Camera.main.GetComponent<ApplePicker>();
            if (this.tag == "Apple")
                applePickerScript.AppleDestroyed();
            

        }   
    }
}
