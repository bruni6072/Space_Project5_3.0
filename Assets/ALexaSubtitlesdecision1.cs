using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALexaSubtitlesdecision1 : MonoBehaviour
{
    public TMPro.TMP_Text alexaDialog_A1;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        
        alexaDialog_A1.text = "The breach has destroyed the whole galaxy, you have failed your mission.";

        yield return new WaitForSeconds(6);
        alexaDialog_A1.text = " ";
    }
}
