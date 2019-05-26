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
        foreach(NodeIOElement _io in gameObject.GetComponent<Node>().IOElements){
            Debug.Log(_io.getType().ToString() + ' ' + _io.gameObject.name);
            if(_io.getType() == ENodeIOElementType.Output){
                foreach(GameObject _edge in _io.edges){
                    Vector3 _temp =  _edge.GetComponent<LineRenderer>().GetPosition(1);
                    Debug.Log(_temp);
                    _edge.GetComponent<LineRenderer>().SetPosition(1, _temp + velocity);
                }
            } else {
                Vector3 _temp =  _io.getEdge().GetComponent<LineRenderer>().GetPosition(0);
                _io.getEdge().GetComponent<LineRenderer>().SetPosition(0, _temp + velocity);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        itemBeingDragged = null;
        //transform.position = startPosition;
    }
}
