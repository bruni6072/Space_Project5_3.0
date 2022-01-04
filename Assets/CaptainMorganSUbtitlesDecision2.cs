using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaptainMorganSUbtitlesDecision2 : MonoBehaviour
{
    public TMPro.TMP_Text captainMorganDialog_A2;
    public GameObject spaceshipScript;
    public Rigidbody spaceshipScriptRigid;

    public GameObject screen1;
    public GameObject screen2;

    public GameObject oldXR;
    public GameObject changeXR;

    public GameObject notesScreen;//Actions that user has to do


    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);//yield on a new YieldInstruction that waits for 1 seconds.
        captainMorganDialog_A2.text = "EGM 126, thanks for answering I will send the instructions of what to do immediately.";

        yield return new WaitForSeconds(6);
        captainMorganDialog_A2.text = " ";

        //To decativate screens
        screen1.SetActive(false);
        screen2.SetActive(false);

         oldXR.SetActive(false);
         changeXR.SetActive(true);//change of XR so you are insede the spaceship


         spaceshipScriptRigid.useGravity = true;//turn on gravity from spaceship
         spaceshipScriptRigid.constraints = RigidbodyConstraints.None;//contrains none



        //Rigidbody gameObjectsRigidBody = spaceshipScript.AddComponent<Rigidbody>(); // Add rigidbody.
        //gameObjectsRigidBody.mass = 10; // Set the GO's mass to 5 via the Rigidbody.
        //gameObjectsRigidBody.useGravity = true;

        spaceshipScript.GetComponent<DroenMovementScriptVR>().enabled = true;// Activate Movement for Spaceship

        notesScreen.SetActive(true);
        
        
    }
}
