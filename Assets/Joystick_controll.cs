using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_controll : MonoBehaviour
{
    public Transform topOfJoystick;

    [SerializeField]
    private float forwardBackwardTilt = 0;
    [SerializeField]
    private float sideTosodeTilt = 0;

    void Update()
    {
        forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
        if( forwardBackwardTilt<335 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);//for number to be +
            Debug.Log("Backward" + forwardBackwardTilt);
        }
        else if(forwardBackwardTilt>5 && forwardBackwardTilt < 74)
        {
            Debug.Log("Forward" + forwardBackwardTilt);
        }

        
        sideTosodeTilt = topOfJoystick.rotation.eulerAngles.z;
        if (sideTosodeTilt < 335 && sideTosodeTilt > 290)
        {
            sideTosodeTilt = Mathf.Abs(sideTosodeTilt - 360);
            Debug.Log("Backward" + sideTosodeTilt);
        }
        else if (sideTosodeTilt > 5 && sideTosodeTilt < 74)
        {
            Debug.Log("Forward" + sideTosodeTilt);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand")) 
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
