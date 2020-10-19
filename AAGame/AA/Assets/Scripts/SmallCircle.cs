using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCircle : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float _velocity;
    public bool _movementControl = false;
    GameObject _gameManager;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void FixedUpdate()
    {
        if (!_movementControl)
        {
            _rigidbody.MovePosition(_rigidbody.position + Vector2.up * _velocity * Time.deltaTime);
        }
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpinningCircleTag") // İf touch spinning cirlce
        {
            transform.SetParent(collision.transform); // Set position and roataion with parent ( Spinnig Circle) object
            _movementControl = true;
            
        }
        if (collision.tag == "SmallCircle") // İf touch other small circle
        {
            _gameManager.GetComponent<GameManager>().StartGameOver();
        }
    }
}
