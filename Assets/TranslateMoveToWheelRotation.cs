using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMoveToWheelRotation : MonoBehaviour {

    public GameObject Wheel;
    public bool RotationHand;

    GameObject centerMarker;
    float radius;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float radius = Wheel.GetComponent<SphereCollider>().radius;

        if (RotationHand)
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
        float liniearDisplacement = +transform.position.x - transform.position.y;
        float angularDisplacement = liniearDisplacement / radius;
        Debug.Log("Liniear Displacement is " + liniearDisplacement + ", and Angular Displacement is " + angularDisplacement);
        Wheel.transform.eulerAngles = new Vector3(Mathf.Rad2Deg * angularDisplacement, 0, 0);


        Wheel.transform.position = new Vector3(0, radius, angularDisplacement);
    }

    void RotationalHandling()
    {
        if (centerMarker != null)
        {
            float displacement = GetAngle(centerMarker.transform.up, transform.position);
            Debug.Log(displacement);
        }
        else
        {
            centerMarker = new GameObject("Marker");
            centerMarker.transform.position = new Vector3(0, 0, 0);
        }
    }

    public float GetAngle(Vector2 from, Vector2 to)
    {
        float angle;

        angle = Mathf.DeltaAngle(Mathf.Atan2(from.y,from.x) * Mathf.Rad2Deg,
                                    Mathf.Atan2(to.y, to.x) * Mathf.Rad2Deg);

        return angle;
    }
}
