﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterUI : MonoBehaviour
{
    //max right value = 264
    //min right value = 564

    public RectTransform meterMask;

    public void UpdateMeter(float anxietyLevel) //anxietyLevel = 0
    {
        float value = (anxietyLevel * 3);
        meterMask.sizeDelta = new Vector2(value, 76);
        //meterMask.SetRight(value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
