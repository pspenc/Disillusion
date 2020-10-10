using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BreathingButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void OnButtonPressed()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
       if(Input.GetKey(KeyCode.B))
        {
            PlayerBase.Instance.ChangeAnxiety(-.03f);
            //GetComponent<Image>().tintColor = new Color(50, 50, 50);
        }
        else
        {
            //GetComponent<Image>().tintColor = Color.white;
        }
    }
}
