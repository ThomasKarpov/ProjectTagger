using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCond : MonoBehaviour
{
    private bool gameWon = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "WinArea")
        {
            Debug.Log("Player won");
            GameObject player = GameObject.Find("Neon Panther");
            player.GetComponent<PlayerMovement>().enabled = false;
            gameWon = true;
            GameObject canvasgw = GameObject.Find("GameWon");
            canvasgw.GetComponent<Canvas>().enabled = true;
            GameObject timerCanvas = GameObject.Find("TimeCanvas");
            timerCanvas.GetComponent<Canvas>().enabled = false;
            GameObject timeManager = GameObject.Find("TimeManager");
            timeManager.GetComponent<TimeManager>().enabled = false;
        }

    }

    void Update()
    {
        if (gameWon == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Prototype 1");
            }

        }
    }



}
