using UnityEngine;
using System.Collections;

public class RotateThis : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    //Make sure you attach a Rigidbody in the Inspector of this GameObject
    Rigidbody m_Rigidbody;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        m_Rigidbody.AddTorque(transform.up * speed * Time.deltaTime);
    }
}