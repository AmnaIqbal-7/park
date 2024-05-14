using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemslot : MonoBehaviour, IDropHandler
{

    public bool _isFill;
   
    public GameObject item
    {
        get
        {
            if (transform.childCount > 1)
            {
                return transform.GetChild(1).gameObject;
            }
            else
            {
                return null;
            }
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item Drop");
        //Destroy(gameObject, 1f);

        if (!item)
        {
            //gameObject.transform.SetParent(transform);
            // Draggable.itemIsDragged.transform.SetParent(transform); /// original line code for set tile parent
            Debug.Log("Drop Child name is : " + ondragdrop.itemIsDragged.GetComponent<TextMeshProUGUI>().text);
            // DragDrop.itemIsDragged.GetComponent<CanvasGroup>().blocksRaycasts = true;
            // DragDrop.itemIsDragged.GetComponent<CanvasGroup>().interactable = false;
            ondragdrop.itemIsDragged.transform.SetParent(transform); /// original line code for set tile parent
            _isFill = true;

            if (eventData.pointerDrag != null)
            {/*
                RectTransform rt = GetComponent<RectTransform>();
                rt.offsetMin = rt.offsetMax = Vector2.zero;*/
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0f);
                Debug.Log("Position set");

                /* GetComponent<RectTransform>().anchoredPosition;*/
            }
            gameObject.GetComponentInChildren<ondragdrop>().enabled = false;
           // GameManager.instance.CheckAllSlotFill();    // check answers
        }
        else
        {
            Destroy(ondragdrop.itemIsDragged);
            Debug.Log("Car Destroyed");
        }

        //if (eventData.pointerDrag != null)
        //{
        //    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
        //        = GetComponent<RectTransform>().anchoredPosition;
        //}
    }
}
