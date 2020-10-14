using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Question[] Questions; // questions array from question class
    public static List<Question> UnAnsweredQuestions;
    public Question _currentQuestion;

    //UI
    public Text _questionText;
    public Button _btn_A;
    public Button _btn_B;
    public Button _btn_C;
    public Button _btn_D;
    public GameObject _questionPanel;
    public GameObject _endGamePanel;
    public Text _correctNumber;
    public Text _wrongNumber;

    public static int _correctAnswerNumber;
    public static int _wrongAnswerNumber;

    void Start()
    {
        if (UnAnsweredQuestions == null)
        {
            UnAnsweredQuestions = Questions.ToList<Question>(); //İf List null create qouestion list from Question Class
        }

        if (UnAnsweredQuestions.Count <= 0) // Control have a other question
        {
            GameOver(); // if list count <=0 finishing the game 
        }
        else
        {
            AskQuestion(); // After Ask Question
        }

    }
    void AskQuestion()
    {
        int _questionIndex = Random.Range(0, UnAnsweredQuestions.Count); // Select Random Index from list
        _currentQuestion = UnAnsweredQuestions[_questionIndex]; // Select this ındex and make current question
        _questionText.text = _currentQuestion._question; // Show on UI

        _btn_A.GetComponentInChildren<Text>().text = _currentQuestion._btn_A_Text;
        _btn_B.GetComponentInChildren<Text>().text = _currentQuestion._btn_B_Text;
        _btn_C.GetComponentInChildren<Text>().text = _currentQuestion._btn_C_Text;
        _btn_D.GetComponentInChildren<Text>().text = _currentQuestion._btn_D_Text;

        UnAnsweredQuestions.RemoveAt(_questionIndex);// Remove this from list
    }
    public void GameOver()
    {
        _questionPanel.SetActive(false);
        _btn_A.gameObject.SetActive(false);
        _btn_B.gameObject.SetActive(false);
        _btn_C.gameObject.SetActive(false);
        _btn_D.gameObject.SetActive(false);

        _correctNumber.text = _correctAnswerNumber.ToString();
        _wrongNumber.text = _wrongAnswerNumber.ToString();
        _endGamePanel.SetActive(true);

    }
    public void Click_Btn_A()
    {
        if (_currentQuestion._answer == 1)
        {
            _btn_A.GetComponent<Image>().color = Color.green;
            _correctAnswerNumber++;
        }
        else
        {
            _btn_A.GetComponent<Image>().color = Color.red;
            _wrongAnswerNumber++;
        }
        StartCoroutine(NextQuestion()); // Load next question.
    }
    public void Click_Btn_B()
    {
        if (_currentQuestion._answer == 2)
        {
            _btn_B.GetComponent<Image>().color = Color.green;
            _correctAnswerNumber++;
        }
        else
        {
            _btn_B.GetComponent<Image>().color = Color.red;
            _wrongAnswerNumber++;
        }
        StartCoroutine(NextQuestion()); // Load next question.
    }
    public void Click_Btn_C()
    {
        if (_currentQuestion._answer == 3)
        {
            _btn_C.GetComponent<Image>().color = Color.green;
            _correctAnswerNumber++;
        }
        else
        {
            _btn_C.GetComponent<Image>().color = Color.red;
            _wrongAnswerNumber++;
        }
        StartCoroutine(NextQuestion()); // Load next question.
    }
    public void Click_Btn_D()
    {
        if (_currentQuestion._answer == 4)
        {
            _btn_D.GetComponent<Image>().color = Color.green;
            _correctAnswerNumber++;
        }
        else
        {
            _btn_D.GetComponent<Image>().color = Color.red;
            _wrongAnswerNumber++;
        }
        StartCoroutine(NextQuestion()); // Load next question.
    }
    public void Click_Btn_Replay()
    {
        string _sceneName = "NewGame";
        Application.LoadLevel(_sceneName);
    }
    public void Click_Btn_Exit()
    {
        Application.Quit();
    }
    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0); // Load this scene again.
    }

}
