using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSPaceship : MonoBehaviour
{
    public Transform spaceShip;
    void LateUpdate()
    {
        Vector3 CameraFollowPosition = spaceShip.position;
        CameraFollowPosition.y = transform.position.y;// we want the height to stay the same
        transform.position = CameraFollowPosition;

    }
}
