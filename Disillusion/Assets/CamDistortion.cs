using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class CamDistortion : MonoBehaviour
{

    PostProcessVolume ppvol;
    bool flipTime = false;
    LensDistortion distort;
    private int frameCount;
    public int anxietyLevel = 0;
    public int maxAnxiety = 100;
    // Start is called before the first frame update
    void Start()
    {
        ppvol = GetComponent<PostProcessVolume>();

        ppvol.profile.TryGetSettings(out distort);

    }

    // Update is called once per frame
    void Update()
    {
        frameCount += 1;
        if (frameCount % 15 == 0)
        {
            if (anxietyLevel < maxAnxiety)
            {
                anxietyLevel += 1;
                if(flipTime)
                {
                    distort.intensity.value = (float)((100-anxietyLevel) * -.6);
                }
                else
                {
                    distort.intensity.value = (float)(anxietyLevel * -.6);
                }
       
            }
            else
            {
                anxietyLevel = 0;
                if(flipTime)
                {
                    flipTime = false;
                }
                else
                {
                    flipTime = true;
                }
            }
        }
    }
}
