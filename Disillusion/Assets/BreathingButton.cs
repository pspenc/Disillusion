using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BreathingButton : MonoBehaviour
{
    public UnityEngine.UI.Image pushedImage;
    public UnityEngine.UI.Image NotPushedImage;
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

        if (Input.GetKey(KeyCode.B))
        {
            PlayerBase.Instance.ChangeAnxiety(-.03f);
            GetComponent<UnityEngine.UI.Image>().color = Color.black;
            //GetComponent<Image>().tintColor = new Color(50, 50, 50);
        }
        else
        {
            if (GetComponent<UnityEngine.UI.Image>())
                GetComponent<UnityEngine.UI.Image>().color = Color.white;
            //GetComponent<Image>().tintColor = Color.white;
        }
    }
}
