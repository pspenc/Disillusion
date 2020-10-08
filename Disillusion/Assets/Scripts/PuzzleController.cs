using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq.Expressions;
//using System.ran

public class PuzzleController : MonoBehaviour
{
    private DropMe[] AllDropme;
    public Sprite[] AllSprite;
    public Material BlurMat;
    // Start is called before the first frame update
    private void Awake()
    {
        AllDropme = GetComponentsInChildren<DropMe>();
        Random.InitState(System.DateTime.UtcNow.Millisecond);
        Assert.IsTrue(AllDropme.Length == AllSprite.Length);
        GetComponent<Image>().material = new Material(BlurMat);
    }
    void ShuffleCurrentIndex()
    {
        int[] tmpArray = new int[AllDropme.Length];
        for (int i = 0; i < AllDropme.Length; i++)
            tmpArray[i] = i;
        for (int i = 0; i < AllDropme.Length; i++)
        {
            int tmp = Mathf.FloorToInt((Random.value) * (AllDropme.Length - i));
            AllDropme[i].CurrentIndex = tmpArray[tmp];
            tmpArray[tmp] = tmpArray[AllDropme.Length - i - 1];
            //print(AllDropme[i].CurrentIndex);
            AllDropme[i].UpdatePic();
        }
    }
    public IEnumerator BeginPuzzle()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PlayerBase.Instance.GetComponent<PlayerController>().EnableMovement = false;
        var ImageArray = GetComponentsInChildren<Image>();
        //foreach (var m_Image in ImageArray) print(m_Image.gameObject.name);
        foreach (var m_Image in ImageArray)
            if (m_Image.gameObject != gameObject)
                m_Image.color = new Color(m_Image.color.r, m_Image.color.g, m_Image.color.b, 0);
        GetComponent<Image>().material.DOFloat(5, "_BlurSize", 1);
        yield return new WaitForSeconds(0.5f);
        //GetComponent<Image>().material.DOColor(Color.black, "_Color", 1f);
        yield return new WaitForSeconds(1f);
        foreach (var m_Image in ImageArray)
            if (m_Image.gameObject != gameObject)
                m_Image.DOFade(0.5f, 1);

        ShuffleCurrentIndex();
        yield return null;
    }
    bool HasEnd = false;
    void Update()
    {
        if (HasEnd) return;
        bool flag = true;
        foreach (var m_Dropme in AllDropme)
        {
            if (!m_Dropme.isSuccess())
            {
                flag = false;
                break;
            }
        }
        if (flag) StartCoroutine(Win());
    }
    IEnumerator Win()
    {
        HasEnd = true;
        PlayerBase.Instance.GetComponent<PlayerController>().EnableMovement = true;
        PlayerBase.Instance.ChangeAnxiety(-1000);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        var ImageArray = GetComponentsInChildren<Image>();
        GetComponent<Image>().material.DOFloat(0, "_BlurSize", 1.5f);
        GetComponent<Image>().material.DOColor(Color.white, "_Color", 1f);
        foreach (var m_Image in ImageArray)
            m_Image.DOFade(0, 0.8f);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        //GetComponentInParent<Canvas>().gameObject.SetActive(false);
        //transform.Find("WinText").GetComponent<Text>().DOFade(1, 1f);

    }
}
