using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatingText : MonoBehaviour
{
    // Start is called before the first frame update


    public float thresholdForAppearing = 50;
    public float howLongToAppearFor = 1;
    //TextMesh text;

    void Start()
    {
        //text = GetComponent<TextMesh>();
        //text.color = Color.black;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerBase.Instance.anxietyLevel > thresholdForAppearing)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            //text.color = Color.white;
        }
        else
        {
            //text.color = Color.black;
            gameObject.GetComponent<Renderer>().enabled = false;
        }


    }
}
