/*
 * Project Name: Project Alpha
 *       Author: Erk
 *         Date: 2020/04/26
 *  Description: The class that handles the Tag System.
 */

using Mirror;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// This script will ONLY run on the server. 
// CharacterTag runs on each clients character!
public class TagSystem : NetworkBehaviour
{
    public static TagSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum GameMode { FFA, TDM, VS };
    [SerializeField] private GameMode mode = GameMode.VS;

    List<PlayerTag> chasers = new List<PlayerTag>();
    List<PlayerTag> targets = new List<PlayerTag>();

    List<PlayerTag> playerTags = new List<PlayerTag>();

    public void AddPlayer(NetworkConnection player)
    {
        Debug.Log($"Player: {player.connectionId} joined.");


        //playerTags.Add(player);
        if (mode == GameMode.VS && playerTags.Count == 2)
        {
            SetCharacterTagsVS();
        }
    }

    // TODO: Remove player from PlayerTags-list if it disconnects


    void SetCharacterTagsVS()
    {
        int targetId = Random.Range(0, playerTags.Count);
        
        targets.Add(playerTags[targetId]);
        playerTags.RemoveAt(targetId);
        chasers.Add(playerTags[0]);

        targets[0].TargetSetTag(targets[0].connectionToClient, true);
        chasers[0].TargetSetTag(chasers[0].connectionToClient, false);
    }

    [Command]
    public void CmdCaughtTag(uint chaser, uint target)
    {
        Debug.Log($"player:{chaser} caught player:{target}");
    }
}
