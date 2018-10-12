using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelParameters : MonoBehaviour {

    float radius;
    public GameObject indicator;

	// Use this for initialization
	void Start () {
        radius = GetComponent<SphereCollider>().radius;
        //indicator = GetComponentInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        indicator.transform.localPosition = Vector3.up * radius;
	}
}
