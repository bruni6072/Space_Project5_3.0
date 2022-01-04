using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AanimationStartGoblin : MonoBehaviour
{
    public Animator anims;

void Start()
    { 
        anims.Play("Goblin_Start");//Triggers animation Start Goblin
    }

}
