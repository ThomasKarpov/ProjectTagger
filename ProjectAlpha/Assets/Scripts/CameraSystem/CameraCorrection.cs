using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCorrection : MonoBehaviour
{

    public Transform player; 

    void Update()
    {
        Vector3 position = transform.position;
        position.x = (player.position).x;
        transform.position = position;
    }
}
