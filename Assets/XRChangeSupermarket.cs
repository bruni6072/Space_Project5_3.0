using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRChangeSupermarket : MonoBehaviour
{
    public GameObject XRChnageNew;
    public GameObject XRold;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Supermarket")
        {
            XRold.SetActive(false);//decativate old xr
            XRChnageNew.SetActive(true);//activate xr in the supermarket
        }
       
    }
}
