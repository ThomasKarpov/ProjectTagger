using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LobbyManager networkManger = null;
    [SerializeField] private Audio_SO menuTrack;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;

    private void Start()
    {
        //Start Menu Music
        AudioMusicController.Instance.PlayTrackMusic_NoLocation(menuTrack);
    }

    public void HostLobby()
    {
        networkManger.StartHost();
        landingPagePanel.SetActive(false);
    }
}
