/*
 * Project Name: Project Alpha
 *       Author: RZU-7
 *         Date: 2020/04/18
 *  Description: Monitors the player input and triggers events if player input
 *               is detected. The input names MUST be defined in the Unity
 *               Input Manager.
 */

using UnityEngine;
using UnityEngine.Events;

public class InputMonitor : MonoBehaviour
{
    public FloatEvent leftButton;
    public FloatEvent rightButton;
    public FloatEvent upButton;
    public FloatEvent downButton;
    public UnityEvent action1Button;
    public UnityEvent action2Button;
    public UnityEvent optionsButton;

    // Update is called once per frame
    void Update()
    {
        CheckAxis(Input.GetAxisRaw("Horizontal"), leftButton, rightButton);

        CheckAxis(Input.GetAxisRaw("Vertical"), downButton, upButton);

        CheckInput(Input.GetButtonDown("Action1"), action1Button);

        CheckInput(Input.GetButtonDown("Action2"), action2Button);

        CheckInput(Input.GetButtonDown("Options"), optionsButton);
    }

    /*
     * @brief Check the value of an axis and trigger the corresponding event.
     *
     * @param axisValue The raw axis value of the axis input
     *
     * @param negativeEvent The FloatEvent to trigger if the raw value is negative
     *
     * @param positiveEvent The FloatEvent to trigger if the raw value is positive
     */
    void CheckAxis(float axisValue, FloatEvent negativeEvent, FloatEvent positiveEvent)
    {
        if (Mathf.Approximately(0, axisValue))
        {
            return;
        }

        if (axisValue < 0)
        {
            negativeEvent.Invoke(axisValue);
            return;
        }

        if (axisValue > 0)
        {
            positiveEvent.Invoke(axisValue);
            return;
        }
    }

    /*
     * @brief Checks if a button is pressed trigger the corresponding event.
     *
     * @param buttonPress The boolean status of the button press
     *
     * @param buttonEvent The UnityEvent to trigger if the button is pressed
     */
    void CheckInput(bool buttonPress, UnityEvent buttonEvent)
    {
        if (buttonPress)
        {
            buttonEvent.Invoke();
        }
    }
}
