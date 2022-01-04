using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSubtittles_Decision1 : MonoBehaviour
{
    public TMPro.TMP_Text GoblinDialog_Decision1_2;
    public Animator goblin_Start;

    public GameObject audioGoblin_Decision1_2;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        goblin_Start.Play("Goblin_Start");//Animation ON
        yield return new WaitForSeconds(1);
        audioGoblin_Decision1_2.SetActive(true);//Audio ON
        GoblinDialog_Decision1_2.text = "Here you go.";//Subtittles


        yield return new WaitForSeconds(5);
        GoblinDialog_Decision1_2.text = " ";
    }
}
