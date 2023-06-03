using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cast();
            Invoke("Cast", 2);
        }
    }

    private void Cast()
    {
        //Cast Animation
        //Catch Promp && Animaiton
        //New Fish
    }
}
