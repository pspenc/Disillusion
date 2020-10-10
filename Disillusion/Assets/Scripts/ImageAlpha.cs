using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlpha : MonoBehaviour
{

    private RawImage rawImage;
    public byte opacity;         //set values in editor
    public double alphaRate;     //set values in editor

    // Start is called before the first frame update
    void Start()
    {
        rawImage = this.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color;
        color = new Color32(0, 0, 0, opacity);
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, color.a);
    }
}
