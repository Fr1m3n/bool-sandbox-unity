using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Controlls : MonoBehaviour
{

    [SerializeField]
    private float zoomSensetivity;

    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float mouseWheelDelta = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize -= mouseWheelDelta * zoomSensetivity;
    }
}
