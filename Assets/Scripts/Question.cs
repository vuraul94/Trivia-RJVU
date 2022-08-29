using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question : MonoBehaviour
{
    public string statement;
    public Answer[] answers;
    public int rightAnswer;
}
