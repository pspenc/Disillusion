using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Image containerImage;
    private Image receivingImage;
    private Color normalColor = Color.white;
    public int TargetIndex;
    [HideInInspector]
    public int CurrentIndex;
    private Color highlightColor = Color.yellow;
    private GameObject m_DraggingIcons;
    private RectTransform m_DraggingPlanes;
    private PuzzleController m_Controller;

    public bool isSuccess()
    {
        return CurrentIndex == TargetIndex;
    }
    private void Awake()
    {
        containerImage = GetComponent<Image>();
        receivingImage = transform.Find("DropImage").GetComponent<Image>();
        m_Controller = GetComponentInParent<PuzzleController>();
    }

    private void Start()
    {
        //print("Container Name " + containerImage.name);
        //print("receiving Name " + receivingImage.name);
        //receivingImage.color = Color.white;
        receivingImage.sprite = null;

    }

    public void OnBeginDrag(PointerEventData data)
    {
        //PlaySwapAudio();
        var canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            return;

        m_DraggingIcons = new GameObject("icon");

        m_DraggingIcons.transform.SetParent(canvas.transform, false);
        m_DraggingIcons.transform.SetAsLastSibling();

        var image = m_DraggingIcons.AddComponent<Image>();
        var group = m_DraggingIcons.AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;
        image.sprite = GetComponent<Image>().overrideSprite;

        receivingImage.overrideSprite = null;
        image.SetNativeSize();
        image.rectTransform.localScale = new Vector3(0.3f, 0.3f, 1);
        //

        //if (dragOnSurfaces)
        //    m_DraggingPlanes[eventData.pointerId] = transform as RectTransform;
        //else
        m_DraggingPlanes = canvas.transform as RectTransform;
        SetDraggedPosition(data);
    }
    public void OnEndDrag(PointerEventData data)
    {
        Destroy(m_DraggingIcons);
        StartCoroutine(CheckIfNull(data.pointerDrag.GetComponent<DropMe>()));
    }
    public void OnDrag(PointerEventData data)
    {
        if (m_DraggingIcons)
            SetDraggedPosition(data);
    }
    public bool CheckImageNull()
    {
        return receivingImage.overrideSprite == null;
    }
    IEnumerator CheckIfNull(DropMe OldDropMe)
    {
        yield return new WaitForEndOfFrame();
        if (OldDropMe.CheckImageNull())
        {
            OldDropMe.UpdatePic();
        }
    }
    private void SetDraggedPosition(PointerEventData eventData)
    {
        //if (dragOnSurfaces && eventData.pointerEnter != null && eventData.pointerEnter.transform as RectTransform != null)
        //    m_DraggingPlanes[eventData.pointerId] = eventData.pointerEnter.transform as RectTransform;

        var rt = m_DraggingIcons.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlanes, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlanes.rotation;
        }
    }


    public void OnDrop(PointerEventData data)
    {
        containerImage.color = normalColor;
        var originalDrop = data.pointerDrag.GetComponent<DropMe>();
        if (originalDrop == null) return;
        int Temp = CurrentIndex;
        CurrentIndex = originalDrop.CurrentIndex;
        originalDrop.CurrentIndex = Temp;

        UpdatePic();
        originalDrop.UpdatePic();
        //receivingImage.overrideSprite = 
        /*
        if (originalPerson == null) return;
        if (!originalDrop.CanBeSwap) return;
        if (m_Person.ID != originalPerson.ID) PlaySwapAudio();
        int Temp = m_Person.ID;
        m_Person.ID = originalPerson.ID;
        //TODO:����ͼƬ�Ƿɹ�ȥ��
        originalPerson.ID = Temp;*/

    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (containerImage == null) return;
        containerImage.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (containerImage == null)
            return;

        containerImage.color = normalColor;
    }

    public void UpdatePic()
    {
        receivingImage.overrideSprite = m_Controller.AllSprite[CurrentIndex];
    }
}
