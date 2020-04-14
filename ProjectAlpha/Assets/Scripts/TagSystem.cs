using Mirror;
using System.Collections;
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
        //if (!isServer)
        //{
        //    Destroy(gameObject);
        //}

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
        Invoke("SetCharacterTags", 3);
    }

    public enum GameMode { FFA, TDM };
    [SerializeField] private GameMode mode = GameMode.TDM;

    List<CharacterTag> chasers = new List<CharacterTag>();
    List<CharacterTag> targets = new List<CharacterTag>();

    CharacterTag[] GetPlayers()
    {
        Thread.Sleep(2000);
        return FindObjectsOfType<CharacterTag>();
    }

    void SetCharacterTags()
    {
        Debug.Log("Setting character tags!");
        var players = GetPlayers();
        if (players.Length == 0)
        {
            Debug.LogError("Failed to find player tags");
            return;
        }
        
        int targetId = Random.Range(0, players.Length);

        for (int i = 0; i < players.Length; i++)
        {
             players[i].TargetSetTag(players[i].connectionToClient, i == targetId?true:false);
        }
    }

    [Command]
    public void CmdCaughtTag(uint chaser, uint target)
    {

    }
}
