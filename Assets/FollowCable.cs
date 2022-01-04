using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCable : MonoBehaviour
{
    public Transform spaceShip;
    public Transform cube;
    void LateUpdate()
    {
        float x = spaceShip.transform.position.x;
        float y = spaceShip.transform.position.y;
        float z = spaceShip.transform.position.z;

        cube.transform.position = new Vector3(x, y, z);

    }
}
