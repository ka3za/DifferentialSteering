using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMoveToWheelRotation : MonoBehaviour {

    public GameObject Wheel;
    public bool OneToOne;

    GameObject centerMarker;

    float lastDisplacement = 0;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        

        if (OneToOne)
        {
            RotationalHandling();
        }
        else
        {
            ForwardHandling();
        }

        //NOTE: USE ANGLE INSTEAD OF DISTANCE TRAVELED!!!!
        //NOTE: SECOND THOUGHT MIGHT WORK WITH DISTANCE ANYWAY!!!

        //NOTE: Make wheelrotation visuals.

        //Tanke: Gå mere efter control af brugbar og brugervenlighed end realisme!
        //Tanke: Kan få andet hjuld til at følje på ligning med % som var. Clamp??
        //Kenni: Skal hånd være i hjul Collider, hvis det bliver en kugle?
    }

    void ForwardHandling()
    {
        float radius = Wheel.GetComponent<SphereCollider>().radius;
        float liniearDisplacement = transform.position.x - transform.position.y;
        float angularDisplacement = liniearDisplacement / radius;
        Debug.Log("Liniear Displacement is " + liniearDisplacement + ", and Angular Displacement is " + angularDisplacement);
        Wheel.transform.eulerAngles = new Vector3(Mathf.Rad2Deg * angularDisplacement, 0, 0);


        Wheel.transform.position = new Vector3(0, radius, angularDisplacement);
    }

    void RotationalHandling()
    {
        float radius = Wheel.GetComponent<SphereCollider>().radius;

        if (centerMarker != null)
        {
            //float displacement = Vector3.Angle(transform.position, centerMarker.transform.position);
            float displacement = GetAngle(transform.position, centerMarker.transform.position);
            Wheel.transform.eulerAngles = new Vector3(0, 0, displacement + 90);
            Debug.Log(displacement);

            


            float distance = ((lastDisplacement * Mathf.PI * radius) / 180) - ((displacement * Mathf.PI * radius) / 180);
            lastDisplacement = displacement;

            //Wheel.transform.position = new Vector3(0, radius, distance);
        }
        else
        {
            centerMarker = new GameObject("CenterMarker");
            centerMarker.transform.position = new Vector3(transform.position.x, transform.position.y - radius, transform.position.z);
        }
    }

    public float GetAngle(Vector2 A, Vector2 B)
    {
        //difference
        var Delta = B - A;
        //use atan2 to get the angle; Atan2 returns radians
        var angleRadians = Mathf.Atan2(Delta.y, Delta.x);

        //convert to degrees
        var angleDegrees = angleRadians * Mathf.Rad2Deg;

        //angleDegrees will be in the range (-180,180].
        //I like normalizing to [0,360) myself, but this is optional..
        if (angleDegrees < 0)
            angleDegrees += 360;

        return angleDegrees;
    }

    private void OnDrawGizmos()
    {
        if (centerMarker != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, centerMarker.transform.position);
            Gizmos.DrawWireSphere(centerMarker.transform.position, 0.25f); 
        }
    }

    void OnGUI()
    {
        //Output the angle found above
        //GUI.Label(new Rect(25, 25, 200, 40), "Angle Between Objects" + m_Angle);
    }
}
