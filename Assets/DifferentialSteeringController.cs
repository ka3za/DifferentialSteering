using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentialSteeringController : MonoBehaviour {

    private float m_rightWheelInput;
    private float m_leftWheelInput;

    public WheelCollider BigWheelRightC, BigWheelLeftC;
    public WheelCollider SmallWheelRightC, SmallWheelLeftC;
    public Transform BigWheelRightT, BigWheelLeftT;
    public Transform SmallWheelRightT, SmallWheelLeftT;
    public float motorForce = 10;

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.RightControl))
        //{
            GetRightInput();
        //}
        //if (Input.GetKey(KeyCode.LeftControl))
        //{
            GetLeftInput();
        //}
        Accelerate();
        UpdateWheelPoses();
    }

    //Only Forward
    public void GetRightInput()
    {
        m_rightWheelInput = Input.GetAxis("Horizontal");//LerpToOne();
    }
    //Only Forward
    public void GetLeftInput()
    {
        m_leftWheelInput = Input.GetAxis("Vertical");//LerpToOne();
    }

    private void Accelerate()
    {
        BigWheelRightC.motorTorque = m_rightWheelInput * motorForce;
        BigWheelLeftC.motorTorque = m_leftWheelInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(BigWheelRightC, BigWheelRightT);
        UpdateWheelPose(BigWheelLeftC, BigWheelLeftT);
        UpdateWheelPose(SmallWheelRightC, SmallWheelRightT);
        UpdateWheelPose(SmallWheelLeftC, SmallWheelLeftT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    float LerpToOne()
    {
        float valToBeLerped = 0;
        float tParam = 0;
        float speed = 0.3f;

        if (tParam < 1)
        {
            tParam += Time.deltaTime * speed; //This will increment tParam based on Time.deltaTime multiplied by a speed multiplier
            valToBeLerped = Mathf.Lerp(0, 1, tParam);
        }

        return valToBeLerped;
    }
}
