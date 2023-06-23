using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    private Animator anim;
    public int minCatch;
    public int maxCatch;

    public float timeToCatchFish;
    public float timer;
    public bool hasCastLine;
    public List<GameObject> fishList = new List<GameObject>();
    public Transform fishSpawn;
    public GameObject player;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //timer used for blah blah, counts down
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && timer > 0 && hasCastLine)
        {
            ReelInFish();
        }

         else if (timer <= 0 && hasCastLine)
         {
             ReturnToNormal();
         }      

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("CastLine", true);
            //StartCoroutine("CaughtFish", Random.Range(minCatch, maxCatch));
            Invoke("CaughtFish", Random.Range(minCatch,maxCatch));
        }
    }
   private void CaughtFish()
   {
        anim.SetBool("CaughtFish", true);
        timer = timeToCatchFish;
        hasCastLine = true;
   }


    private void ReelInFish()
    {
        //this does a 
        anim.SetBool("CaughtFish", false);
        anim.SetBool("CastLine", false);
        Instantiate(fishList[Random.Range(0, fishList.Count)], fishSpawn.position, player.transform.rotation, player.transform);
        hasCastLine = false;
        Debug.Log("Caught");
    }


    private void ReturnToNormal()
    {
        anim.SetBool("CastLine", false);
        anim.SetBool("CaughtFish", false);
        hasCastLine = false;
        Debug.Log("Miss");
    }

}
