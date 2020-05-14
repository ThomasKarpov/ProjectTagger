using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text _displayedTime=null;

    [Tooltip("Time the game runs in seconds")]
    [SerializeField]
    private float _roundLength = 5;

    public delegate void TimeSpent();
    public static event TimeSpent OnTimeSpent;
    public void StartTimer() 
    {
        StartCoroutine(_Countdown(_roundLength));
    }
    public void StopTimer() 
    {
        StopCoroutine(_Countdown(_roundLength));
    }
    private IEnumerator _Countdown(float duration) 
    {
        float timeSpent = 0;
        while (timeSpent <= duration) 
        {
            timeSpent += Time.deltaTime;
            float remaining = duration - timeSpent;
            _displayedTime.text = _ConvertTimeToString((int)remaining);
            yield return null;
        }
        OnTimeSpent?.Invoke();
        StopTimer();
    }
    private string _ConvertTimeToString(int seconds) 
    {
        System.TimeSpan time = System.TimeSpan.FromSeconds(seconds);
        return time.ToString(@"mm\:ss");
    }
}
