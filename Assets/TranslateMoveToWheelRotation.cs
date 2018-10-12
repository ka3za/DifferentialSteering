using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMoveToWheelRotation : MonoBehaviour {

    public GameObject Wheel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Wheel.transform.eulerAngles = transform.position;
	}
}
