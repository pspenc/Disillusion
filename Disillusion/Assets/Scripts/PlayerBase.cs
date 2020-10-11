using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerBase : SingletonBase<PlayerBase>
{

    public float anxietyLevel;
    public float maxAnxiety;
    private int frameCount;
    public Image Background;
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
    bool HasDied=false;
    void Update()
    {
        
        if(IsBreathing)
        {
            ChangeAnxiety(-.01f);
        }

        if (Background && !HasDied && Mathf.Approximately(anxietyLevel, maxAnxiety))
            StartCoroutine(IDie());
        meterUI.UpdateMeter(anxietyLevel);


    }
    IEnumerator IDie()
    {
        HasDied = true;
        transform.GetComponent<PlayerController>().EnableMovement = false;
        Background.DOFade(1, 1);
        //TODO Play an Audio
        yield return new WaitForSeconds(3);
        
        SceneManager.LoadScene(0);
    }
}
