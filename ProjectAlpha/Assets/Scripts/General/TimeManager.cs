using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    bool gameOver = false;
    public float timer = 14f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GameOver();
        }

        if (gameOver == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(1);
            }

        }
    }

    void GameOver()
    {
        gameOver = true;
        GameObject canvasgo = GameObject.Find("GameOver");
        canvasgo.GetComponent<Canvas>().enabled = true;
    }

}
