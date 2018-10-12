using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInteractable : MonoBehaviour {

    //Meget af det her skal sikkert på det gribte objekt.

    Transform grabbed;
    float grabDistance = 10.0f;


void Update()
    {
            UpdateHoldDrag();
    }


    void UpdateHoldDrag()
    {
        if (Input.GetMouseButton(0))
            if (grabbed)
                Drag();
            else
                Grab();
        else
            grabbed = null;
    }

    void Grab()
    {
        if (grabbed)
            grabbed = null;
        else
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                grabbed = hit.transform;
        }
    }

    void Drag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 position = transform.position + transform.forward * grabDistance;
        Plane plane = new Plane(-transform.forward, position);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            grabbed.position = ray.origin + ray.direction * distance;
            //grabbed.rotation = transform.rotation;
        }
    }
}
