using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
//using System.ran

public class PuzzleController : MonoBehaviour
{
    private DropMe[] AllDropme;
    public Sprite[] AllSprite;
    // Start is called before the first frame update
    private void Awake()
    {
        AllDropme = GetComponentsInChildren<DropMe>();
        Random.InitState(System.DateTime.UtcNow.Millisecond);
    }
    void Start()
    {
        Assert.IsTrue(AllDropme.Length == AllSprite.Length);
        ShuffleCurrentIndex();
    }
    void ShuffleCurrentIndex()
    {
        int[] tmpArray = new int[AllDropme.Length];
        for (int i = 0; i < AllDropme.Length; i++)
            tmpArray[i] = i;
        for (int i = 0; i < AllDropme.Length; i++)
        {
            int tmp = Mathf.FloorToInt((Random.value) * (AllDropme.Length - i));
            AllDropme[i].CurrentIndex = tmpArray[tmp] ;
            tmpArray[tmp] = tmpArray[AllDropme.Length - i - 1];
            AllDropme[i].UpdatePic();
        }
    }
    // Update is called once per frame
    void Update()
    {
        bool flag = true;
        foreach (var m_Dropme in AllDropme)
        {
            if (!m_Dropme.isSuccess())
            {
                flag = false;
                break;
            }
        }
        if (flag) transform.Find("WinText").GetComponent<Text>().color = Color.black;
    }
}
