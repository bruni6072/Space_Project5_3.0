using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainMorganSubtitles : MonoBehaviour
{
    public TMPro.TMP_Text captainMorganDialog;

    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(1);//yield on a new YieldInstruction that waits for 1 seconds.
        captainMorganDialog.text = "This is captain Morgan, from the galaxy safety association, I request immediate support.";
        
        yield return new WaitForSeconds(6);
        captainMorganDialog.text = "There has been a breach in space and  we are not going to be able to hold it for much longer.";

        yield return new WaitForSeconds(5);
        captainMorganDialog.text = "I repeat, this is captain Morgan, from the galaxy safety association, I request immediate support.";

        yield return new WaitForSeconds(7);
        captainMorganDialog.text = "There has been a breach in space and we are not going to be able to hold it for much longer.";

        yield return new WaitForSeconds(5);
        captainMorganDialog.text = " ";
    }
}
