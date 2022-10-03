using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite unclicked;
    public Sprite clicked;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = clicked;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = unclicked;
    }
}
