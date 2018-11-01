using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPointMovement : MonoBehaviour {

    public float speed = 1;

    public float lenghtBetweenWheelsFromCenter;

    public GameObject RWheel;
    public GameObject LWheel;

    public float radius;

    Vector3 rotationPoint;
    Vector3 direction;

	// Use this for initialization
	void Start () {
        rotationPoint = transform.position;

        RWheel.transform.position = transform.position + new Vector3(lenghtBetweenWheelsFromCenter, 0, 0);
        LWheel.transform.position = transform.position + new Vector3(-lenghtBetweenWheelsFromCenter, 0, 0);
    }
	

    /*
     * 
     * 
    */


	// Update is called once per frame
	void Update () {

        direction = transform.position - rotationPoint;

        radius = Vector3.Distance(transform.position, rotationPoint);

        if (Input.GetKey(KeyCode.Space))
        {
            Quaternion rot = Quaternion.AngleAxis(180*Time.deltaTime*speed, rotationPoint);
            transform.position = rotationPoint + rot * direction;
            transform.localRotation = rot;


            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //transform.RotateAround(rotationPoint, Vector3.up, speed * Time.deltaTime);

            //transform.SetPositionAndRotation(RotatePointAroundPivot(transform.position, rotationPoint, transform.up), Quaternion.LookRotation(rotationPoint - transform.position));
            //transform.position = RotatePointAroundPivot(transform.position, rotationPoint, transform.up);

            //transform.position += (transform.rotation * rotationPoint);

            //transform.rotation *= Quaternion.AngleAxis(90*Time.deltaTime, Vector3.up);

            //transform.position -= (transform.rotation * rotationPoint);
        }

        if (Input.GetKey(KeyCode.RightControl))
        {
            //transform.Rotate(Vector3.up * (speed * 60) * Time.deltaTime);
            //rotationPoint.Set(transform.localPosition.x * speed / 4 * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
            rotationPoint += transform.right * speed / 4 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            //transform.Rotate(Vector3.up * (speed * 60) * Time.deltaTime);
            rotationPoint -= transform.right * speed / 4 * Time.deltaTime;
        }


        //Rotate with rotation point in second field!
        RotationPointDirection(transform.position, rotationPoint);
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }

    public void RotationPointDirection(Vector3 transform, Vector3 rotationPoint)
    {

        //Skal Fikses
        if (transform.magnitude > rotationPoint.magnitude)
        {
            //Debug.Log("Left");
        }
        if (transform.magnitude < rotationPoint.magnitude)
        {
            //Debug.Log("Right");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(rotationPoint, 0.25f);
        Gizmos.DrawLine(transform.position, rotationPoint);
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * 2);
        //Gizmos.DrawWireCube(transform.position + Vector3.forward * 2, new Vector3(.2f,.2f,.2f));
    }
}
