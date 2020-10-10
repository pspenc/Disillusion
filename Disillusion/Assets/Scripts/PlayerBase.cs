using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : SingletonBase<PlayerBase>
{

    public float anxietyLevel;
    public float maxAnxiety;
    private int frameCount;

    public MeterUI meterUI;
    public bool IsBreathing = false;

    // Start is called before the first frame update
    void Start()
    {
        anxietyLevel = 0;
        maxAnxiety = 100;

        meterUI.UpdateMeter(anxietyLevel);

    }


    public void StartBreathing()
    {
        IsBreathing = true;
    }
    public void StopBreathing()
    {
        IsBreathing = false;
    }
    public void ChangeAnxiety(float delta)
    {
        anxietyLevel += delta;
        anxietyLevel = Mathf.Clamp(anxietyLevel, 0, maxAnxiety);
    }
    // Update is called once per frame
    void Update()
    {

        if(IsBreathing)
        {
            ChangeAnxiety(-.01f);
        }


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
