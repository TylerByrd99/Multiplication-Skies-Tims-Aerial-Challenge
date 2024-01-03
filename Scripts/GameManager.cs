using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Problem[] problems;          // list of all problems
    public int curProblem;              // current problem the player needs to solve
    public float timePerProblem;        // time allowed to answer each problem
    public float remainingTime;         // time remaining for the current problem
    public PlayerController player;     // player object
    public static GameManager instance; // instance

    void Awake ()
    {
        // set instance to this script
        instance = this;
    }

    void Start ()
    {
        // set the initial problem
        SetProblem(0);
    }

    void Update ()
    {
        remainingTime -= Time.deltaTime;

        // check if the remaining time ran out
        if(remainingTime <= 0.0f)
        {
            Lose();
        }
        // check if player hit "esc" key to exit game
        if(Input.GetKey("escape"))
        {
            Application.Quit(); 
        }
    }

    // called when the player enters a tube
    public void OnPlayerEnterTube (int tube)
    {
        // check if player entered the correct tube
        if (tube == problems[curProblem].correctTube)
        {
            CorrectAnswer();
        }
    }

    // called when the player enters the correct tube
    void CorrectAnswer()
    {
        // check if this is the last problem
        if(problems.Length - 1 == curProblem)
            Win();
        else
            SetProblem(curProblem + 1);
    }

    // sets the current problem
    void SetProblem (int problem)
    {
        curProblem = problem;
        UI.instance.SetProblemText(problems[curProblem]);
        remainingTime = timePerProblem;
    }

    // called when the player answers all the problems
    void Win ()
    {
        Time.timeScale = 0.0f;
        UI.instance.SetEndText(true);
    }

    // called if the remaining time on a problem reaches 0
    void Lose ()
    {
        Time.timeScale = 0.0f;
        UI.instance.SetEndText(false);
    }
}