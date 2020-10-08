using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : SingletonBase<PlayerBase>
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
    public void ChangeAnxiety(int delta)
    {
        anxietyLevel += delta;
        anxietyLevel = Mathf.Clamp(anxietyLevel, 0, maxAnxiety);
    }
    // Update is called once per frame
    void Update()
    {
        meterUI.UpdateMeter(anxietyLevel);
        /*
        frameCount += 1;
        if (frameCount % 15 == 0)
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
        */


    }
}
