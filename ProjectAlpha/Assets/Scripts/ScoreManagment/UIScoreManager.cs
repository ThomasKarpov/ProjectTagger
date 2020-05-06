using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreManager : MonoBehaviour
{
    
    [SerializeField]
    private Text _winner=null;
    [SerializeField]
    private Text _winCondition = null;
    [SerializeField]
    private Text timerDisplayed = null;
    [SerializeField]
    private Text _timeRemaining = null;
    [SerializeField]
    private Text _catcherScore = null;
    [SerializeField]
    private Text _runnerScore = null;
    [SerializeField]
    GameObject winUI = null;
    public void ShowVictory(string winner, bool caught, int catcherScore, int runnerScore) 
    {
        _UpdateWinner(winner, caught);
        _timeRemaining.text = timerDisplayed.text;
        _UpdateScores(catcherScore, runnerScore);
        winUI.SetActive(true);
    }
    private void _UpdateWinner(string winner, bool caught) 
    {
        _winner.text = winner;
        if (caught)
            _winCondition.text = "by catching everyone";
        else
            _winCondition.text = "by evading being caught";
    }
    private void _UpdateScores(int catcherScore, int runnerScore) 
    {
        _catcherScore.text = catcherScore.ToString();
        _runnerScore.text = runnerScore.ToString();
    }
}
