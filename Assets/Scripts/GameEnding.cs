using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameEnding : MonoBehaviour
{
    public GameObject player;
    public GameObject winCanvas;
    public TMP_Text timerText;
    public TMP_Text winText;

    void Start()
    {
        winCanvas.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            winCanvas.SetActive(true);
            winText.text = "You Win!";
            
        }
    }
}
