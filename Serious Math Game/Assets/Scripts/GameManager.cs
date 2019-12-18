using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Problem[] problems;
    public int curProblem;
    public float timePerProblem;
    public float remainingTime;
    public PlayerController player;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetProblem(0);
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;

        if(remainingTime <= 0)
        {
            Lose();
        }
    }

    public void OnPlayerEnterTube(int tube)
    {
        if(tube == problems[curProblem].correctTube)
        {
            CorrectAnswer();
        }
        else
        {
            IncorrectAnswer();
        }
    }

    void CorrectAnswer()
    {
        if(problems.Length -1 == curProblem)
        {
            Win();
        }
        else
        {
            SetProblem(curProblem + 1);
        }
    }

    void IncorrectAnswer()
    {
        player.Stun();
    }

    void SetProblem(int problem)
    {
        curProblem = problem;
        UI.instance.SetProblemText(problems[curProblem]);
        remainingTime = timePerProblem;
    }

    void Win()
    {
        Time.timeScale = 0.0f;
        UI.instance.SetEndText(true);
    }

    void Lose()
    {
        Time.timeScale = 0.0f;
        //set ui losescreen
        UI.instance.SetEndText(false);
    }
}
