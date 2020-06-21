using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerRole
{
    CHASER,
    RUNNER
}

public enum PlayerAssignment
{
    PLAYER1,
    PLAYER2
}

public static class EnumHelpers
{
    public static string AssignmentToString(PlayerAssignment assignment)
    {
        switch (assignment)
        {
            case PlayerAssignment.PLAYER1:
                return "Player 1";
            case PlayerAssignment.PLAYER2:
                return "Player 2";
            default:
                return "None";
        }
    }
}
