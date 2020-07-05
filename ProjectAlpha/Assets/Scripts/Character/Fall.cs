using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    bool gameOver = false; 

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "BottomLimit")
        {
            Debug.Log("Player fell off the screen");
            GameObject player = GameObject.Find("Neon Panther");
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            gameOver = true;
            GameObject canvasgo = GameObject.Find("GameOver");
            canvasgo.GetComponent<Canvas>().enabled = true;
            GameObject timerCanvas = GameObject.Find("TimeCanvas");
            timerCanvas.GetComponent<Canvas>().enabled = false;

        }
    }


    void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(1);
            }

        }
    }
}