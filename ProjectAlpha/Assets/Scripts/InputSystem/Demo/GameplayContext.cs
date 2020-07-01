/*
 * Project Name: Project Alpha
 *       Author: RZU-7
 *         Date: 2020/04/18
 *  Description: The context used in the main gameplay loop.
 */

using UnityEngine;

public class GameplayContext : BaseContext
{
    private readonly GameManager gameManager;

    public GameplayContext(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private PlayerMovement playerMovement;

    public void SetPlayer(PlayerMovement _player)
    {
        playerMovement = _player;
    }

    /*
     * @brief Moves the player left.
     *
     * @param value The raw axis value of the axis input
     */
    override public void LeftButtonAction(float value)
    {
        if(playerMovement)
        {
            playerMovement.SetHorizontalSpeed(value);
        }
        //Debug.Log(string.Format("Player is MOVING LEFT with raw value {0}", value));
    }

    /*
     * @brief Moves the player right.
     * 
     * @param value The raw axis value of the axis input
     */
    override public void RightButtonAction(float value)
    {
        if (playerMovement)
        {
            playerMovement.SetHorizontalSpeed(value);
        }
        //Debug.Log(string.Format("Player is MOVING RIGHT with raw value {0}", value));
    }

    /*
     * @brief Moves the player up.
     *
     * @param value The raw axis value of the axis input
     */
    override public void UpButtonAction(float value)
    {
        Debug.Log(string.Format("Player is MOVING UP with raw value {0}", value));
    }

    /*
     * @brief Moves the player down.
     *
     * @param value The raw axis value of the axis input
     */
    override public void DownButtonAction(float value)
    {
        Debug.Log(string.Format("Player is MOVING DOWN with raw value {0}", value));
    }

    /*
     * @brief Makes the player jump.
     */
    override public void Action1ButtonAction()
    {
        if (playerMovement)
        {
            playerMovement.Jump();
        }
        //Debug.Log("Player is JUMPING");
    }

    /*
     * @brief Makes the player dash.
     */
    override public void Action2ButtonAction()
    {
        if (playerMovement)
        {
            playerMovement.Dash();
        }
        //Debug.Log("Player is DASHING");
    }

    /*
     * @brief Opens up the options menu
     */
    override public void OptionsButtonAction()
    {
        Debug.Log("Player opened the options MENU.");
        gameManager.pauseMenuToggled.Invoke();
    }
}

