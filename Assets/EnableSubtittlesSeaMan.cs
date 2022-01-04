using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSubtittlesSeaMan : MonoBehaviour
{
    public TMPro.TMP_Text seaMan_Text;

    public GameObject seaMan_Audio;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        seaMan_Audio.SetActive(true);//Audio ON
        seaMan_Text.text = "Don't you see I am sleeping? Go away!";//Subtittles


        yield return new WaitForSeconds(5);
        seaMan_Text.text = " ";
    }
}
