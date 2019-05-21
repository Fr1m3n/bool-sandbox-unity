using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrabHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    private GameObject itemBeingDragged;
    private Vector3 startPosition;
    private Vector3 perviousPosition;

    public void OnBeginDrag(PointerEventData eventData){
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        perviousPosition = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData){
        Vector3 velocity = Input.mousePosition - perviousPosition;
        perviousPosition = Input.mousePosition;
        transform.position += velocity;
    }

    public void OnEndDrag(PointerEventData eventData){
        itemBeingDragged = null;
        //transform.position = startPosition;
    }
}
