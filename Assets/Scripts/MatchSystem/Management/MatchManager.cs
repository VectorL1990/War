using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    enum WinFlag {Team1Win, Team2Win, Normal};

    //Team_1 players
    public Player[] Team1Players;

    //Team_2 players
    public Player[] Team2Players;

    public Point[] AllPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePhysCalculate()
    {
        for (int i = 0; i < AllPoints.Length; i++)
        {
            
        }
    }

    WinFlag JudgeWin()
    {
        int DeadNb = 0;
        for (int i = 0; i < Team1Players.Length; i++)
        {
            if (Team1Players[i].isDead)
            {
                DeadNb += 1;
            }
        }
        if (DeadNb == Team1Players.Length)
        {
            return WinFlag.Team1Win;
        }
        
        DeadNb = 0;
        for (int i = 0; i < Team2Players.Length; i++)
        {
            if (Team2Players[i].isDead)
            {
                DeadNb += 1;
            }
        }
        if (DeadNb == Team2Players.Length)
        {
            return WinFlag.Team2Win;
        }

        return WinFlag.Normal;
    }
}
