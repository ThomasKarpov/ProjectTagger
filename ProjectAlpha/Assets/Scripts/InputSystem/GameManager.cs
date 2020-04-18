/*
 * Project Name: Project Alpha
 *       Author: RZU-7
 *         Date: 2020/04/18
 *  Description: This is a sample Game Manager to illustrate the use of the
 *               input system.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent pauseMenuToggled;

    public ContextManager contextManager;
    public GameplayContext gameplayContext;
    public MenuContext menuContext;

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
}
