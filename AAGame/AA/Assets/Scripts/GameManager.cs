using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    GameObject _spinningCircle;
    GameObject _mainCircle;
    public Animator _animator;

    // UI
    public Text _currentLevel;
    public Text _first_MainCircle_Text;
    public Text _second_MainCircle_Text;
    public Text _third_MainCircle_Text;

    public int _totalNumberOfCircle;
    bool _controlGameOver;

    void Start()
    {
        PlayerPrefs.SetInt("SavingLevel", int.Parse(SceneManager.GetActiveScene().name)); // save current level

        _spinningCircle = GameObject.FindGameObjectWithTag("SpinningCircleTag");
        _mainCircle = GameObject.FindGameObjectWithTag("MainCircle");
        _currentLevel.text = SceneManager.GetActiveScene().name; // Get level

        if (_totalNumberOfCircle < 2)
        {
            _first_MainCircle_Text.text = _totalNumberOfCircle.ToString();
        }
        else if (_totalNumberOfCircle < 3)
        {
            _first_MainCircle_Text.text = _totalNumberOfCircle.ToString();
            _second_MainCircle_Text.text = (_totalNumberOfCircle - 1).ToString();
        }
        else
        {
            _first_MainCircle_Text.text = _totalNumberOfCircle.ToString();
            _second_MainCircle_Text.text = (_totalNumberOfCircle - 1).ToString();
            _third_MainCircle_Text.text = (_totalNumberOfCircle - 2).ToString();
        }
    }

    public void ShowTextOnSmallCircle() // Update text on small circles
    {
        _totalNumberOfCircle--;
        if (_totalNumberOfCircle < 2)
        {
            _first_MainCircle_Text.text = _totalNumberOfCircle.ToString();
            _second_MainCircle_Text.text = "";
            _third_MainCircle_Text.text = "";
        }
        else if (_totalNumberOfCircle < 3)
        {
            _first_MainCircle_Text.text = _totalNumberOfCircle.ToString();
            _second_MainCircle_Text.text = (_totalNumberOfCircle - 1).ToString();
            _third_MainCircle_Text.text = "";
        }
        else
        {
            _first_MainCircle_Text.text = _totalNumberOfCircle.ToString();
            _second_MainCircle_Text.text = (_totalNumberOfCircle - 1).ToString();
            _third_MainCircle_Text.text = (_totalNumberOfCircle - 2).ToString();
        }

        if (_totalNumberOfCircle == 0)
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        _spinningCircle.GetComponent<TurningCircle>().enabled = false;
        _mainCircle.GetComponent<MainCircle>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (!_controlGameOver)
        {
            _animator.SetTrigger("NextLevel"); // Plaing next level animation
            yield return new WaitForSeconds(2); // wait 2 second
            SceneManager.LoadScene((int.Parse(SceneManager.GetActiveScene().name) + 1).ToString());
        }
        
    }

    public void StartGameOver()
    {
        StartCoroutine(GameOver()); // Call game over method
    }
    IEnumerator GameOver()
    {
        _spinningCircle.GetComponent<TurningCircle>().enabled = false;
        _mainCircle.GetComponent<MainCircle>().enabled = false;
        _animator.SetTrigger("GameOver"); // Plaing game over animation
        _controlGameOver = true;
        yield return new WaitForSeconds(3); // wait 2 second
        SceneManager.LoadScene("MainMenu"); // Load main menu
    }

}
