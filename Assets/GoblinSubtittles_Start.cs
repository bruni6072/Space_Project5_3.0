using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSubtittles_Start : MonoBehaviour
{
    public TMPro.TMP_Text GoblinDialog_Start;
    public Animator goblin_Start;

    public GameObject audioGoblin_start;

    public GameObject decisions;//buttons

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        goblin_Start.Play("Goblin_Start");//Animation ON
        yield return new WaitForSeconds(1);
        audioGoblin_start.SetActive(true);//Audio ON
        GoblinDialog_Start.text = "Hello son, what would you like to buy?";//Subtittles
       

        yield return new WaitForSeconds(5);
        GoblinDialog_Start.text = " ";
        decisions.SetActive(true);
    }
}
