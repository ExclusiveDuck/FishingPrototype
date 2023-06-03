using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    Mouse mouse;

    [SerializeField] GameObject uiDialogue;
    [SerializeField] GameObject objective;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject triggerText;
    [SerializeField] GameObject fishingRod;


    private void Start()
    {
        mouse = GameObject.Find("Player").GetComponentInChildren<Mouse>();
    }
    private void OnTriggerEnter(Collider other)
    {
        triggerText.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                triggerText.SetActive(false);
                uiDialogue.SetActive(true);
                mouse.canMoveMouse = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerText.SetActive(false);
            uiDialogue.SetActive(false);
            mouse.canMoveMouse = true;
   
        }
    }

    public void ActivateObjective()
    {
        objective.SetActive(true);
        triggerText.SetActive(false);
        uiDialogue.SetActive(false);

        fishingRod.SetActive(true);
    }
}
