/*
 * Project Name: Project Alpha
 *       Author: RZU-7
 *         Date: 2020/04/18
 *  Description: This is a sample Game Manager to illustrate the use of the
 *               input system.
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent pauseMenuToggled;

    public ContextManager contextManager;
    public GameplayContext gameplayContext;
    public MenuContext menuContext;

    public List<PlayerData> playerList;
    bool enableDecideWinner;
    bool startTimer;
    public double gameMaxTimer = 1f;
    double gameCurrentTimer;

    Dictionary<string, BaseContext> contextDispenser;
    bool menuToggle;

    // Start is called before the first frame update
    void Start()
    {
        // Assign contexts to a container
        contextDispenser = new Dictionary<string, BaseContext>
        {
            { "gameplay", gameplayContext },
            { "menu", menuContext }
        };

        if (playerList.Count < 2)
        {
            Debug.LogException(new Exception("playerList List does not have a minimum of 2 players."));
        }

        startTimer = true;
        gameCurrentTimer = gameMaxTimer;
    }

    private void Update()
    {
        if (startTimer && gameCurrentTimer > 0f)
        {
            gameCurrentTimer -= Time.deltaTime;
        }
        if (gameCurrentTimer <= 0f)
        {
            enableDecideWinner = true;
            gameCurrentTimer = gameMaxTimer;
            startTimer = false;
        }
    }

    /*
     * @brief Toggles between the menu context and the gameplay context.
     */
    public void ToggleMenu()
    {
        menuToggle = !menuToggle;

        if (menuToggle)
        {
            contextManager.currentContext = contextDispenser["menu"];
            Debug.Log("Switched context to \"menu\"");
        }
        else
        {
            contextManager.currentContext = contextDispenser["gameplay"];
            Debug.Log("Switched context to \"gameplay\"");
        }    
    }

    public void DecideWinner()
    {
        if (enableDecideWinner)
        {
            foreach (PlayerData player in playerList)
            {
                if (player.role == PlayerRole.CHASER)
                {
                    Debug.Log("GAME ENDED: " + EnumHelpers.AssignmentToString(player.assignment) + " wins!");
                }
            }
        }
        
    }
}
