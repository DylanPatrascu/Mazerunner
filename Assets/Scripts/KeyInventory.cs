using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public bool hasRedKey = false;
    public bool hasGreenKey = false;
    public bool hasBlueKey = false;

    public void PickupKey(int key)
    {
        if(key == 1)//red
        {
            hasRedKey = true;
        }
        else if(key == 2)//green
        {
            hasGreenKey = true;
        }
        else //blue
        {
            hasBlueKey = true;
        }
    }

    public bool CheckKey(int key)
    {
        if (key == 1)//red
        {
            return hasRedKey;
        }
        else if (key == 2)//green
        {
            return hasGreenKey;
        }
        else //blue
        {
            return hasBlueKey;
        }
    }
}
