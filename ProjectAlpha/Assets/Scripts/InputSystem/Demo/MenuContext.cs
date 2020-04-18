/*
 * Project Name: Project Alpha
 *       Author: RZU-7
 *         Date: 2020/04/18
 *  Description: The context used for navigating menus.
 */

using UnityEngine;

public class MenuContext : BaseContext
{
    public GameManager gameManager;

    public MenuContext(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    /*
     * @brief Moves the current selection up
     *
     * @param value The raw axis value of the axis input
     */
    override public void LeftButtonAction(float value)
    {
        Debug.Log("Moved current SELECTION LEFT");
    }

    /*
     * @brief Moves the current selection right.
     * 
     * @param value The raw axis value of the axis input
     */
    override public void RightButtonAction(float value)
    {
        Debug.Log("Moved current SELECTION RIGHT");
    }

    /*
     * @brief Moves the current selection up.
     *
     * @param value The raw axis value of the axis input
     */
    override public void UpButtonAction(float value)
    {
        Debug.Log("Moved current SELECTION UP");
    }

    /*
     * @brief Moves the current selection down.
     *
     * @param value The raw axis value of the axis input
     */
    override public void DownButtonAction(float value)
    {
        Debug.Log("Moved current SELECTION DOWN");
    }

    /*
     * @brief Selects the currently selected option
     */
    override public void Action1ButtonAction()
    {
        Debug.Log("Current menu item SELECTED");
    }

    /*
     * @brief No op.
     */
    override public void Action2ButtonAction()
    {
        return;
    }

    /*
     * @brief Moves up a level in menu scope
     */
    override public void OptionsButtonAction()
    {
        Debug.Log("menu CLOSED");
        gameManager.pauseMenuToggled.Invoke();
    }
}

