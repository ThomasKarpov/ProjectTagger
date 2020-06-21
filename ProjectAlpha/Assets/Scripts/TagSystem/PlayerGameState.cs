using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGameState : MonoBehaviour
{
    public UnityEvent playerCollided;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Players")
        {
            Debug.Log("Collided with player");
            playerCollided.Invoke();
        }
    }
}
