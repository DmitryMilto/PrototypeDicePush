using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Timer Timer;
    [SerializeField] private GameObject Target;
    void Update()
    {
        if (Timer.currentSeconds <= 0f) {
            if (Input.GetMouseButtonDown(0)) //нажали
            {
                Debug.Log("GetMouseButtonDown");
            }

            if (Input.GetMouseButton(0)) // держали
            {
                //SetTarget();
                Debug.Log("GetMouseButton");
            }

            if (Input.GetMouseButtonUp(0)) //отпустили
            {
                Debug.Log("GetMouseButtonUp");
                Timer.shot = true;
            } 
        }
    }
    /*private void SetTarget()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider == null) return;

            Target.transform.position = hit.point;
        }
    }*/
}
