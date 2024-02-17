using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LookAt_Camera : MonoBehaviour
{
    Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        gameObject.transform.forward = -cam.forward;
    }
}
