using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentialSteeringController : MonoBehaviour {

    private float m_rightWheelInput;
    private float m_leftWheelInput;
    private float input;

    public WheelCollider BigWheelRightC, BigWheelLeftC;
    //public WheelCollider SmallWheelRightC, SmallWheelLeftC;
    public Transform BigWheelRightT, BigWheelLeftT;
    //public Transform SmallWheelRightT, SmallWheelLeftT;
    [Range(1, 20)]
    public int MotorForce = 10;
    [Range(0, 100)]
    public int PartnerWheelHelp = 20;

    private void FixedUpdate()
    {
        GetRightInput();
        GetLeftInput();
        Accelerate();
        //FrontWheelsSteering();
        UpdateWheelPoses();
    }

    public void GetRightInput()
    {
        m_rightWheelInput = Input.GetAxis("Horizontal");
    }

    public void GetLeftInput()
    {
        m_leftWheelInput = Input.GetAxis("Vertical");
    }

    public void SetInput(float force)
    {
        input = force;
    }

    private void Accelerate()
    {
        //BigWheelRightC.motorTorque = (m_rightWheelInput * (PartnerWheelHelp / 100)) +m_rightWheelInput * MotorForce;
        //BigWheelLeftC.motorTorque = (m_rightWheelInput * (PartnerWheelHelp / 100))+m_leftWheelInput  * MotorForce;
        BigWheelRightC.motorTorque = input;
        BigWheelLeftC.motorTorque = input;
    }

    private void FrontWheelsSteering()
    {
        Vector3 FrontRot = Quaternion.identity.eulerAngles;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(BigWheelRightC, BigWheelRightT);
        UpdateWheelPose(BigWheelLeftC, BigWheelLeftT);
        //UpdateWheelPose(SmallWheelRightC, SmallWheelRightT);
        //UpdateWheelPose(SmallWheelLeftC, SmallWheelLeftT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }
}
