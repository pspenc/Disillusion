using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    public int anxietyLevel;
    public int maxAnxiety;
    private int frameCount;

    public MeterUI meterUI;


    // Start is called before the first frame update
    void Start()
    {
        anxietyLevel = 0;
        maxAnxiety = 100;

        meterUI.UpdateMeter(anxietyLevel);

    }

    // Update is called once per frame
    void Update()
    {
        frameCount += 1;
        if (frameCount % 3 == 0)
        {
            if (anxietyLevel < maxAnxiety)
            {
                anxietyLevel += 1;
                meterUI.UpdateMeter(anxietyLevel);
            }
            else
            {
                anxietyLevel = 0;
                meterUI.UpdateMeter(anxietyLevel);
            }
        }

        
    }
}
