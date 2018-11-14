using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInteractable : MonoBehaviour {

    private GameObject GrabedGO;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.green);

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.tag == "Interactable")
                {
                    if (GrabedGO == null)
                    {
                        GrabedGO = hit.transform.gameObject;
                        Debug.Log(hit.transform.name + " is selected.");

                        GrabedGO.transform.position = new Vector3(Input.mousePosition.x, hit.transform.position.y);
                    }
                }

            }
        }
        Debug.Log("Released " + GrabedGO.name);
        GrabedGO = null;
	}
}
