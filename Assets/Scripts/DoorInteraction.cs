using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public KeyInventory keyInventory;
    public GameObject player;
    public int currentDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && keyInventory.CheckKey(currentDoor) == true)
        {
            Animator doorAnimator = gameObject.GetComponent<Animator>();
            doorAnimator.SetBool("CanOpen", true);
        }
    }
}
