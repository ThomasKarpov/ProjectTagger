/*
 * Project Name: Project Alpha
 *       Author: RZU-7
 *         Date: 2020/04/18
 *  Description: Wraps the currentContext methods so they can be subscribed to
 *               event listeners while allowing the context to be dynamically
 *               changed.
 */

using UnityEngine;

public class ContextManager : MonoBehaviour
{
    public BaseContext currentContext;

    /*
     * @brief Abstract method for executing an action based on the leftButton press.
     *
     * @param value The raw axis value of the axis input
     */
    public void LeftButtonAction(float value)
    {
        currentContext.LeftButtonAction(value);
    }

    /*
     * @brief Abstract method for executing an action based on the rightButton press.
     * 
     * @param value The raw axis value of the axis input
     */
    public void RightButtonAction(float value)
    {
        currentContext.RightButtonAction(value);
    }

    /*
     * @brief Abstract method for executing an action based on the upButton press.
     *
     * @param value The raw axis value of the axis input
     */
    public void UpButtonAction(float value)
    {
        currentContext.UpButtonAction(value);
    }

    /*
     * @brief Abstract method for executing an action based on the downButton press.
     *
     * @param value The raw axis value of the axis input
     */
    public void DownButtonAction(float value)
    {
        currentContext.DownButtonAction(value);
    }

    /*
     * @brief Abstract method for executing an action based on the action1Button press.
     */
    public void Action1ButtonAction()
    {
        currentContext.Action1ButtonAction();
    }

    /*
     * @brief Abstract method for executing an action based on the action2Button press.
     */
    public void Action2ButtonAction()
    {
        currentContext.Action2ButtonAction();
    }

    /*
     * @brief Abstract method for executing an action based on the optionsButton press.
     */
    public void OptionsButtonAction()
    {
        currentContext.OptionsButtonAction();
    }
}
