using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MathsOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
[System.Serializable]
public class Problem
{
    public float firstNumber;
    public float secondnumber;
    public MathsOperation operation;
    public float[] answers;

    public int correctTube;
}
