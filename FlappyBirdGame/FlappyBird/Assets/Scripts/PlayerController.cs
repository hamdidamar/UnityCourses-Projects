using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _flyPower;
    private Rigidbody2D _rigidBody;

    public bool _startGame;
    public bool _endGame;
    public int _score;

    public GameObject _endGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !_endGame)
        {
            if (!_startGame)
            {
                _rigidBody.gravityScale = 1;
                _startGame = true;
            }
            
            Fly();
        }
    }
    void FixedUpdate()
    {
        if (_startGame && !_endGame)
        {
            FlightAngle();
        }
    }
    void Fly()
    {
        _rigidBody.velocity = Vector2.zero; // we make the speed zero
        _rigidBody.AddForce(new Vector2(0, _flyPower)); // we apply as much force as flight power only on the y-axis

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="DeathArea")
        {
            _endGame = true;
            StartCoroutine(EndGame()); // Game Over
        }

        if (collision.tag == "ScoreArea")
        {
            _score += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "DeathArea") // transform tag because it's a collision
        {
            _endGame = true;
            StartCoroutine(EndGame()); // Game Over
        }
    }

    void FlightAngle()
    {
        float angle = 35;

        if (_rigidBody.velocity.y < 0)
        {
            angle = Mathf.Lerp(35, -60, -(_rigidBody.velocity.y) / 10);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0); // Wait 0 seconds
        _endGamePanel.SetActive(true); // Visible panel is open
        Time.timeScale = 0; // For stop update methods

    }
}
