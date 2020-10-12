using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleHandler : MonoBehaviour
{

    // -301 Mask starting X
    //  634 Mask ending X

    public Button button;
    public VideoPlayer videoPlayer;
    public Image buttonMask;
    public VideoClip transitionVideo;
    public int titlePhase;

    private float buttonAlpha; //doesn't realy work, fading in images a headache
    private Image image;
    private RectTransform maskTransform;

    // Start is called before the first frame update
    void Start()
    {
        titlePhase = 0;
        buttonAlpha = 0f;
        image = button.GetComponent<Image>();
        //button.transform.localScale = Vector3.zero;
        buttonMask.gameObject.SetActive(false);
        //button.gameObject.SetActive(false);
        videoPlayer.Play();

        maskTransform = buttonMask.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePhase();
        UpdateButton();
        UpdateTransition();
    }

    // Update phase of title screen
    void UpdatePhase()
    {
        int newPhase = titlePhase;
        switch (newPhase)
        {
            case 0:
                if (isVideoDone(videoPlayer.time))
                {
                    newPhase = 1;
                }
                break;
        }
        titlePhase = newPhase;
    }

    void UpdateButton()
    {


        if (titlePhase == 1)
        {
            buttonMask.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            float x = (maskTransform.position.x + (1 / ((maskTransform.position.x / 2500))));
            if (x < 2500)
            {
                maskTransform.position = new Vector3(x, maskTransform.position.y, 0);
            }
            if (x > 500)
            {
                UnityEngine.Debug.Log("interactable");
                button.interactable = true;
            }
        }
        /*
        else if (titlePhase == 2)
        {
            if (image.color.a < 0.1f)
            {
                button.gameObject.SetActive(false);
            }
        }
        */
    }

    //Update transition to next scene
    void UpdateTransition()
    {
        if (titlePhase == 2 && isVideoDone(videoPlayer.time))
        {
            //transition logic
            UnityEngine.Debug.Log("transition here");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            titlePhase = 3;
        }
    }


    //check video finished
    bool isVideoDone(double time)
    {
        if (time >= 3.95)
        {
            //UnityEngine.Debug.Log("returned true.");
            return true;
        }
        else
        {
            //UnityEngine.Debug.Log("returned false.");
            return false;
        }
    }

    //input process for start button
    public void StartInput()
    {
        button.interactable = false;
        titlePhase = 2;
        videoPlayer.clip = transitionVideo;
        videoPlayer.Play();
    }
}
