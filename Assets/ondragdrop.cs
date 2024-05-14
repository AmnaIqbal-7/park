using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ondragdrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField]  Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    //------------------------------------------------------


    //   private RectTransform parentToReturnTo = null;



    Vector3 StartPos;
    public static GameObject itemIsDragged;
    public bool isStart = true;
    private void Awake()
    {
       // canvas = GameObject.FindGameObjectWithTag("GameCanvas").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        // gameObject.GetComponent<CarMovement>().speed = 0;

        // Destroy(gameObject.GetComponent<CarMovement>());
        // this.gameObject.GetComponent<CarMovement>().enabled = false;
        canvasGroup.blocksRaycasts = false;

        itemIsDragged = gameObject;

         StartPos = transform.position;
        Debug.Log("On Begin Drag");
        canvasGroup.blocksRaycasts = false;
      //  var rot = transform.rotation;
       // transform.rotation = rot * Quaternion.Euler(0, 0, 90); // this is 90 degrees around z axis
                                                               // rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
                                                               //  LeanTween.alphaCanvas(canvasGroup, .6f, .5f);
                                                               // LeanTween.scale(bRect, new Vector2(1f, 1f), .5f); //.setEase(LeanTweenType.easeOutBounce);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //  Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        //  isStart = false;
        //  canvasGroup.blocksRaycasts = true;
        //parentToReturnTo.anchoredPosition += evenData.delta / canvas.scaleFactor;
        //  this.transform.position = evenData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        // Debug.Log("Car Drop");
        //  Destroy(this.gameObject);


        canvasGroup.alpha = 1f;
        itemIsDragged = null;
         transform.position = StartPos;
        ////canvasGroup.blocksRaycasts = false;
        canvasGroup.blocksRaycasts = true;
       // Destroy(this.gameObject);

        // LeanTween.alphaCanvas(canvasGroup, 1f, .5f);
        //   LeanTween.scale(bRect, new Vector2(0.698212f, 0.698212f), .5f); //.setEase(LeanTweenType.easeOutBounce);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

    }

    public void OnDrop(PointerEventData eventData)
    {


    }
}