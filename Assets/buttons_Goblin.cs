using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons_Goblin : MonoBehaviour
{
    public GameObject decision_Activate;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "choice")
        {
            decision_Activate.SetActive(true);
        }
    }

}
