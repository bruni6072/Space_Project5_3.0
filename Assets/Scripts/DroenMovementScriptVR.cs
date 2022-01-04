using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using System;
//using UnityEngine.InputSystem;


public class DroenMovementScriptVR : MonoBehaviour
{

    //public static InputFeatureUsage<Vector2> primary2DAxis;
    public InputDevice targetDevice;

    Rigidbody ourDrone;
    //private InputDevice targetDevice;

    private void Start()
    {
        var leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);

        foreach (var device in leftHandedControllers)
        {
            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }

        if (leftHandedControllers.Count > 0)
        {
            targetDevice = leftHandedControllers[0];
        }
    }

    private void Awake()
    {
        ourDrone = GetComponent<Rigidbody>();//gets Rigidbody from drone

    }

    private void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();
        LimitSpeedValues();

        ourDrone.AddRelativeForce(Vector3.up * upForce);//For drone to levitate
        ourDrone.AddRelativeForce(Vector3.forward * forwardForce);
        ourDrone.rotation = Quaternion.Euler( //Aply tilt to drone
           new Vector3(tiltAmountForward, currentYRotation, ourDrone.rotation.z)//CurrentYRotation= rotation(J & L)
             );

    }



    public float upForce;//Check forces in inspector
    private void MovementUpDown()
    {
        /*Vector2 joystickValue;
        if (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out joystickValue))//Vertical= S or W (if pressed)
        {
            if (joystickValue[1] > 0.2f)
            {
                Vector2 joystickValu;

                if ((targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerValu) && triggerValu) || (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool gripValu) && gripValu))
                {
                    ourDrone.velocity = ourDrone.velocity;//to always let go faster or slower
                }
                if (!(targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerVal) && triggerVal)
                    && !(targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool gripVal) && gripVal)
                    && !(targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out joystickValu) && joystickValu[0] > new Vector2(0.75f, 00f)[0]))//not Keys pressed

                {
                    ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);//if not keys pressed, velocity=0 so not going anywhere (Y= stopping)
                    upForce = 281;//if we move forward
                }
                if (!(targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerVa) && triggerVa)
                    && !(targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool gripVa) && gripVa)
                    && (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out joystickValu) && joystickValu[0] > new Vector2(0.75f, 00f)[0]))// I & K not pressed & either J or L pressed
                {
                    ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                    upForce = 110;
                }
                if (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out joystickValu) && joystickValu[0] > new Vector2(0.75f, 00f)[0])
                {
                    upForce = 410;
                }
            }
            if (joystickValue[1] < 0.2f)
            {
                upForce = 450;
            }
        }*/


        //bool triggerValue;
        //bool gripValue;


        if (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerValue) && triggerValue)// "I" pressed
        {
            upForce = 150;

        }
        else if (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool gripValue) && gripValue)// "K" prssed
        {
            upForce = 30;

        }
        else //if (!(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValu)) && !(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValu)))
        {
            upForce = 98.1f;// Gravity Force
        }


    }



    private float movementForwardSpeed = 100.0f;
    private float tiltAmountForward = 0;//Tilt(Inclination) when going forward
    private float tilitVelocityForward;//"unecessary"
    public float forwardForce;
    //public Vector2 joystickValue;

    private void MovementForward()
    {

        Vector2 joystickValue;
        if (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out joystickValue))//Vertical= S or W (if pressed)
        {
            if (joystickValue[1] > new Vector2(0.0f, 0.75f)[1])//(0,0) -----> upward position in joystick
            {
                ourDrone.AddRelativeForce(Vector3.forward * joystickValue[1] * movementForwardSpeed);//will slowly acccelerate
                                                                                                     //tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * joystickValue[1], ref tilitVelocityForward, 0.1f);//tilt in right direction, 20=tilt value
                                                                                                     // upForce = upForce + upForce * joystickValue[1];
                                                                                                     //forwardForce = 100;
            }
            else if (joystickValue[1] < new Vector2(0.0f, -0.75f)[1])// -----> downward position in joystick
            {
                ourDrone.AddRelativeForce(Vector3.forward * joystickValue[1] * movementForwardSpeed);//will slowly acccelerate
                //tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * joystickValue[1], ref tilitVelocityForward, 0.1f);//tilt in right direction, 20=tilt value
                //forwardForce = -100;
            }
            else
            {
                forwardForce = 0;

            }
        }
    }


    private float wantedYRotation;
    [HideInInspector] public float currentYRotation;//Public for Camera follow script
    private float rotateAmountByKeys = 1.5f;//How much increment roattion
    private float rotationYVelocity;//"unecessary"
    private void Rotation()
    {
        Vector2 joystickValue;
        if (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out joystickValue))
        {

            if (joystickValue[0] > new Vector2(0.75f, 00f)[0])//
            {
                wantedYRotation += rotateAmountByKeys; //increase

            }
            if (joystickValue[0] < new Vector2(-0.75f, 00f)[0])// 
            {

                wantedYRotation -= rotateAmountByKeys;// decrease
            }
            currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
        }

    }

    private Vector3 velocityToZero;
    private void LimitSpeedValues()
    {
        Vector2 joystickValue;
        if (targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out joystickValue))
        {
            if (joystickValue[0] > 0.2f || joystickValue[1] > 0.2f)
            {
                ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));//5f= time it takes to accelerate, 10f= max velocity, basically limiting velocity
            }

            if (joystickValue[0] < 0.2f || joystickValue[1] < 0.2f)//No keys pressed Basically to stop
            {
                ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToZero, 0.95f);
            }
        }
    }
}


