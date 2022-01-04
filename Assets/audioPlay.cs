using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour
{
    public GameObject alexathink1;
   


    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(3);//yield on a new YieldInstruction that waits for 4 seconds.
        alexathink1.SetActive(true);
    }
}
