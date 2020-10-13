using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float _minRange;
    public float _maxRange;

    public GameObject _topPipe;
    public GameObject _bottomPipe;

    private SpriteRenderer _topRenderer;
    private SpriteRenderer _bottomRenderer;

    

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        RemovePipe();
    }

    void Setup()
    {
        _topRenderer = _topPipe.GetComponent<SpriteRenderer>();
        _bottomRenderer = _bottomPipe.GetComponent<SpriteRenderer>();


        float _temp = Random.Range(-4.05f + _minRange, 5);
        _topPipe.transform.position = new Vector2(transform.position.x, _temp);

        float _temp2 = Random.Range(_minRange, _maxRange);
        _bottomPipe.transform.position = new Vector2(transform.position.x, _temp - _temp2);
    }


    void RemovePipe()
    {
        if (transform.position.x < 0 && !_topRenderer.isVisible && !_bottomRenderer.isVisible) // if it has passed the midpoint and is not visible on the screen
        {
            Destroy(this.gameObject); // Remove thisgame object
        }
    }
}
