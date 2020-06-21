/*
 * Project Name: Project Alpha
 *       Author: Erk
 *         Date: 2020/04/26
 *  Description: The class that handles settings up the name above each characters head.
 */

using Mirror;
using TMPro;
using UnityEngine;

public class PlayerNameText : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Transform target;
    private NetworkIdentity netID;

    private void Start()
    {
        netID = transform.root.GetComponent<NetworkIdentity>();
        if (netID && !netID.isLocalPlayer)
        {
            nameText.text = $"Player {netID.netId}";
            enabled = false;
        }
        else
        {
            nameText.text = "You";
        }

        if (!target) { }
            //target = Camera.main.transform;
    }

    void Update()
    {
        if(target)
            transform.LookAt(target);
    }
}
