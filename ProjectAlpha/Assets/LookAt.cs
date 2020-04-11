using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]private Transform target;
    void Update()
    {
        if (!target)
            target = Camera.main.transform;

        transform.LookAt(target);
    }
}
