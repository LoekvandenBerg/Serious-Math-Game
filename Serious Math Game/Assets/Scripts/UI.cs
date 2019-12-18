using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text problemText;
    public Text[] answerTexts;
    public Image timeDial;
    private float timeDialRate;
    public Text endText;

    public static UI instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeDialRate = 1.0f / GameManager.instance.timePerProblem;
    }

    private void Update()
    {
        timeDial.fillAmount = timeDialRate * GameManager.instance.remainingTime;
    }

    public void SetProblemText(Problem problem)
    {
        string operatorText = "";

        switch (problem.operation)
        {
            case MathsOperation.Addition:
                operatorText = " + ";
                break;
            case MathsOperation.Subtraction:
                operatorText = " - ";
                break;
            case MathsOperation.Division:
                operatorText = " ÷ ";
                break;
            case MathsOperation.Multiplication:
                operatorText = " x ";
                break;
        }

        problemText.text = problem.firstNumber + operatorText + problem.secondnumber;

        for(int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = problem.answers[i].ToString();
        }
    }

    public void SetEndText(bool win)
    {
        endText.gameObject.SetActive(true);
        if (win)
        {
            endText.text = "You Win!";
            endText.color = Color.green;
        }
        else
        {
            endText.text = "Game Over!";
            endText.color = Color.red;
        }
    }
}
