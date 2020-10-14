using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterUpdate : MonoBehaviour
{

    public Material[] PosterMats;
    public Texture2D[] OldPosterImage;
    public Texture2D[] NewPosterImage;
    public float SwitchAtAnxietyPercent = 0.5f;
    // Start is called before the first frame update
    bool isNew = false;
    // Update is called once per frame
    private void Start()
    {
        for (int i = 0; i < PosterMats.Length; i++)
            if (PosterMats[i] && OldPosterImage[i]) PosterMats[i].SetTexture("_MainTex", OldPosterImage[i]);
        isNew = false;
    }
    void Update()
    {
       
        if (PlayerBase.Instance.anxietyLevel >= PlayerBase.Instance.maxAnxiety * SwitchAtAnxietyPercent
            && !isNew)
        {
            print("DEBUG NEW");
            for (int i = 0; i < PosterMats.Length; i++)
                if (PosterMats[i] && NewPosterImage[i]) PosterMats[i].SetTexture("_MainTex", NewPosterImage[i]);
            isNew = true;
        }
        else if (PlayerBase.Instance.anxietyLevel < PlayerBase.Instance.maxAnxiety * SwitchAtAnxietyPercent
        && isNew)
        {
            print("DEBUG OLD");
            for (int i = 0; i < PosterMats.Length; i++)
                if (PosterMats[i] && OldPosterImage[i]) PosterMats[i].SetTexture("_MainTex", OldPosterImage[i]);
            isNew = false;
        }
    }
}
