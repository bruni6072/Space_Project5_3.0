using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSubtittles_Decision3 : MonoBehaviour
{
    public TMPro.TMP_Text GoblinDialog_Decision3;
    public Animator goblin_Laugh;


    public GameObject audioGoblin_Decision3;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        goblin_Laugh.Play("Goblin_Laugh");//Animation ON
        yield return new WaitForSeconds(1);
        audioGoblin_Decision3.SetActive(true);//Audio ON
        yield return new WaitForSeconds(1);
        GoblinDialog_Decision3.text = "ha, ha I am sure you need some, but it’s not like you can recover your dignity just by buying it.";//Subtittles


        yield return new WaitForSeconds(8);
        GoblinDialog_Decision3.text = " ";
    }
}

