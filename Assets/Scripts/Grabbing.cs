using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour {

    public GameObject sphere;
    public GameObject Wheelchair;

    private GameObject insObj;
    private DifferentialSteeringController wheelchairScript;

    // Use this for initialization
    void Start () {

        wheelchairScript = Wheelchair.GetComponent<DifferentialSteeringController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        //insObj = Instantiate(sphere, transform.position, transform.rotation);

    }

    private void OnTriggerStay(Collider other)
    {
       if(true)  // <--- Code For testing movement
       // if (Input.GetMouseButton(1))
        {
            Debug.Log("Mousepressed");
            if (insObj == null)
            {
                Debug.Log("ToSphere");
                insObj = Instantiate(sphere, transform.position, transform.rotation); 

            }

            Vector3 pos1 = insObj.transform.position;

            if (insObj != null)
            {
                insObj.transform.position = transform.position;
            }

            float dist = Vector3.Distance(insObj.transform.position, pos1);

            if (pos1.z > insObj.transform.position.z)
            {
                dist = dist * -1;
            }

            float force = dist / Time.fixedDeltaTime;

            Debug.Log("Distance:" + dist);
            Debug.Log("Force:" + force);

            wheelchairScript.SetInput(force);
        }

     /*  else 
        {      
            Destroy(insObj);  
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");

        if (insObj != null)
        {
            
            Destroy(insObj); 
        }

        wheelchairScript.SetInput(0);

    }
}
