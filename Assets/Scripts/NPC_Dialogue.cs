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
    [SerializeField] GameObject dialogueButton;
    [SerializeField] GameObject finishButton;

    public float dialogueCounter;

    private void Start()
    {
        mouse = GameObject.Find("Player").GetComponentInChildren<Mouse>();
    }

    private void Update()
    {
        if (dialogueCounter == 0)
        {
            text.text = "Hello Traveller...";
        }
        if (dialogueCounter == 1)
        {
            text.text = "Glad to see you as I am in need of some help...";
        }
        if (dialogueCounter == 2)
        {
            text.text = "I need some fish to feed my family, however I have a terrible fear of water...";
        }
        if (dialogueCounter == 3)
        {
            text.text = "If you can catch me one of each fish, I will reward you!";
        }
        if (dialogueCounter == 4)
        {
            text.text = "Will you help me?";
        }
        if (dialogueCounter == 5)
        {
            text.text = "Great!, My fishing rod is over by the pier... goodluck!";
            dialogueButton.SetActive(false);
            finishButton.SetActive(true);
        }
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

    public void NextDialogue()
    {
        dialogueCounter++;
    }

    public void PreviousDialogue()
    {
        dialogueCounter--;
    }
    public void ActivateObjective()
    {
        objective.SetActive(true);
        triggerText.SetActive(false);
        uiDialogue.SetActive(false);

        fishingRod.SetActive(true);
    }
}
