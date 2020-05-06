using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    Timer _timer = null;
    [SerializeField]
    private UIScoreManager _uiScoreManager = null;
    private int _catcherScore = 0;
    private int _runnerScore = 0;
    void Start()
    {
        Timer.OnTimeSpent += _OutOfTime;
        //CatchMechanic.OnCaught+=_CaughtRunner; //turn me on when ready
        _timer.StartTimer();
    }
    private void _OutOfTime() 
    {
        _runnerScore++;
        _uiScoreManager.ShowVictory("Runner", false, _catcherScore, _runnerScore);
        
    }
    private void _CaughtRunner() 
    {
        _catcherScore++;
        _uiScoreManager.ShowVictory("Catcher", true, _catcherScore, _runnerScore);
        _timer.StopTimer();

    }
}