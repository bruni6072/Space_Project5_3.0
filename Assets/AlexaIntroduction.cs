using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexaIntroduction : MonoBehaviour
{
    public TMPro.TMP_Text alexaIntroduction1_Text;

    public GameObject audioAlexa1;
    public GameObject audioAlexa2;

    public GameObject activateCaptainMorgan;


    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(4);

        audioAlexa1.SetActive(true);
        alexaIntroduction1_Text.text = "You are the pilot abord the EGM 126 spaceship and Your mission is to protect this galaxy against fatalities";

        yield return new WaitForSeconds(8);
        audioAlexa2.SetActive(true);
        alexaIntroduction1_Text.text = "The safety of this galaxy is in your hands.";

        yield return new WaitForSeconds(4);
        alexaIntroduction1_Text.text = " ";


        yield return new WaitForSeconds(7);
        activateCaptainMorgan.SetActive(true);// Activate Captain Morgan Transmission
    }
}
