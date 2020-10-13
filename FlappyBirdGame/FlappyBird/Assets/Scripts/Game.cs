using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private float _timer;
    public float _maxTime;
    public float _minTime;
    public GameObject _pipePrefab;
    public Transform _createPipePoint;

    public PlayerController PlayerController;

    public Text _score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_timer <= 0 && PlayerController._startGame)
        {
            CreatePipe();
        }

        _timer -= Time.deltaTime;

        Score(); // For UI
    }

    void CreatePipe()
    {
        Instantiate(_pipePrefab, _createPipePoint.position, _createPipePoint.rotation);
        _timer = Random.Range(_minTime, _maxTime);
    }

    void Score() // Write score on UI
    {
        _score.text = PlayerController._score.ToString();
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
