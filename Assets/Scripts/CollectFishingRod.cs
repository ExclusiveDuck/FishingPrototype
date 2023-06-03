using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFishingRod : MonoBehaviour
{
    [SerializeField] GameObject playerFishingrod;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerFishingrod.SetActive(true);
            Destroy(gameObject);
        }
    }
}
