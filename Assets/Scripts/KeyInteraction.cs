using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public KeyInventory keyInventory;
    public GameObject player;
    public int currentKey;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            keyInventory.PickupKey(currentKey);
            gameObject.SetActive(false);
        }
    }
}
