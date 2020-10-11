using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public void OnButtonAnimationFinished()
    {
        gameObject.transform.localScale = Vector3.zero;
        SceneManager.LoadScene(1);

    }
}
