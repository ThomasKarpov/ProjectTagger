/*
 * Project Name: Project Alpha
 *       Author: RZU-7
 *         Date: 2020/04/18
 *  Description: The base class for the input contexts.
 */

using UnityEngine;

public abstract class BaseContext : MonoBehaviour
{
    /*
     * @brief Abstract method for executing an action based on the leftButton press.
     *
     * @param value The raw axis value of the axis input
     */
    abstract public void LeftButtonAction(float value);

    /*
     * @brief Abstract method for executing an action based on the rightButton press.
     * 
     * @param value The raw axis value of the axis input
     */
    abstract public void RightButtonAction(float value);

    /*
     * @brief Abstract method for executing an action based on the upButton press.
     *
     * @param value The raw axis value of the axis input
     */
    abstract public void UpButtonAction(float value);

    /*
     * @brief Abstract method for executing an action based on the downButton press.
     *
     * @param value The raw axis value of the axis input
     */
    abstract public void DownButtonAction(float value);

    /*
     * @brief Abstract method for executing an action based on the action1Button press.
     */
    abstract public void Action1ButtonAction();

    /*
     * @brief Abstract method for executing an action based on the action2Button press.
     */
    abstract public void Action2ButtonAction();

    /*
     * @brief Abstract method for executing an action based on the optionsButton press.
     */
    abstract public void OptionsButtonAction();
}
