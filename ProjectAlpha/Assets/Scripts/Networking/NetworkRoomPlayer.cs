using Mirror;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkRoomPlayer : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject lobbyUI = null;
    [SerializeField] private TMP_Text[] playerNameTexts = new TMP_Text[4];
    [SerializeField] private Image[] playerSlots = new Image[4];
    [SerializeField] private Button StartGameButton;

    [SerializeField] private Color readyColor;
    [SerializeField] private Color notReadyColor;


    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string DisplayName = "Loading...";
    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;

    private bool isLeader;

    public bool IsLeader 
    { 
        set 
        { 
            isLeader = value;
            StartGameButton.gameObject.SetActive(value); 
        } 
    }

    private LobbyManager room;
    public LobbyManager Room 
    { 
        get 
        {
            if (room != null) { return room; }
            return room = NetworkManager.singleton as LobbyManager;
        }
    }

    public void HandleReadyStatusChanged(bool oldValue, bool newValue) => UpdateDisplay();
    public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();

    public override void OnStartAuthority()
    {
        CmdSetDisplayName(PlayerNameInput.DisplayName);

        if(isLocalPlayer)
            lobbyUI.SetActive(true);
    }

    [Command]
    private void CmdSetDisplayName(string displayName)
    {
        DisplayName = displayName;
    }

    [Command]
    public void CmdReadyUp()
    {
        IsReady = !IsReady;
        Room.NotifyPlayersOfReadyState();
    }

    [Command]
    public void CmdStartGame()
    {
        if(Room.RoomPlayers[0].connectionToClient != connectionToClient) { return; }

        // Start Game
        Room.StartGame();
    }

    public override void OnStartClient()
    {
        Room.RoomPlayers.Add(this);
        //lobbyUI.SetActive(true);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if(!isLocalPlayer)
        {
            foreach (var player in Room.RoomPlayers)
            {
                if(player.isLocalPlayer)
                {
                    player.UpdateDisplay();
                    break;
                }
            }
            return;
        }

        for (int i = 0; i < playerNameTexts.Length; i++)
        {
            playerNameTexts[i].text = "Empty";
            playerSlots[i].color = notReadyColor;
        }

        for (int i = 0; i < Room.RoomPlayers.Count; i++)
        {
            playerNameTexts[i].text = Room.RoomPlayers[i].DisplayName;
            playerSlots[i].color = Room.RoomPlayers[i].IsReady ? 
                readyColor : notReadyColor;
        }
    }

    public void HandleReadyToStart(bool readyToStart)
    {
        if (!isLeader) { return; }
        StartGameButton.interactable = readyToStart;
    }

    public override void OnNetworkDestroy()
    {
        Room.RoomPlayers.Remove(this);

        UpdateDisplay();
    }


}
