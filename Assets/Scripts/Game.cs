using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Difficulty[] questionBank;

    public TextMeshProUGUI statement;

    public TextMeshProUGUI[] answers;

    public int questionLevel;

    public Question currentQuestion;

    public ComplementaryPanel complementaryPanel;

    public Button[] btn_answer;

    private void Start()
    {
        LoadQuestionBank();
        questionLevel = 0;
        SetQuestion();
    }

    public void SetQuestion()
    {
        int randomQuestion =
            Random.Range(0, questionBank[questionLevel].questions.Length);
        currentQuestion = questionBank[questionLevel].questions[randomQuestion];
        statement.text = currentQuestion.statement;
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].text = currentQuestion.answers[i].text;
        }
    }

    public void EvaluateQuestion(int playerAnswer)
    {
        if (playerAnswer == currentQuestion.rightAnswer)
        {
            questionLevel++;
            if (questionLevel == questionBank.Length)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                try
                {
                    complementaryPanel.Deploy();
                }
                catch (System.Exception ex)
                {
                    Debug
                        .LogError("You forgot set up the complementary panel: " +
                        ex.Message);
                }
                EnableQuestions();
            }
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void EnableQuestions()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            try
            {
                btn_answer[i].gameObject.SetActive(true);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Button wasn't setted: " + ex.Message);
            }
        }
    }

    public void LoadQuestionBank()
    {
        try
        {
            questionBank =
                JsonConvert
                    .DeserializeObject<Difficulty[]>(File
                        .ReadAllText(Application.streamingAssetsPath+"/QuestionBank.json"));
        }
        catch(System.Exception ex)
        {
            statement.text = ex.Message;
        }
    }
}
